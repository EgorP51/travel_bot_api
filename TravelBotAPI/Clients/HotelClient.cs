using TravelBotAPI.Constants;
using TravelBotAPI.Models;
using Newtonsoft.Json;

namespace TravelBotAPI.Clients
{
    public class HotelClient
    {
        private string city;

        public HotelClient()
        {
        }

        public async Task<HotelModel> GetHotelsAsync(string city,string checkin,string checkout,int adults)
        {
            string uri = $"https://airbnb13.p.rapidapi.com/search-location?location={city}&checkin={checkin}&checkout={checkout}&adults={adults.ToString()}&children=0&infants=0&page=1";
            Console.WriteLine(uri);
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(uri),
                Headers =
                {
                    { "X-RapidAPI-Key", Constant.apiKey },
                    { "X-RapidAPI-Host", "airbnb13.p.rapidapi.com" },
                },
            };
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(body);
                Console.ResetColor();
                HotelModel hotelModel = JsonConvert.DeserializeObject<HotelModel>(body);
                if(hotelModel.results != null)
                {
                    return hotelModel;
                }
                else
                {

                    Console.WriteLine("null1");
                    return null;
                }
            }
            else
            {
                Console.WriteLine("null1");
                return null;
            }
        }

    }
}
