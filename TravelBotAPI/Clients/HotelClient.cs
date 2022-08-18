using TravelBotAPI.Constants;
using TravelBotAPI.Models;
using Newtonsoft.Json;

namespace TravelBotAPI.Clients
{
    public class HotelClient
    {
        public async Task<HotelModel?> GetHotelsAsync(string city,string checkin,string checkout,int adults)
        {
            string uri = $"https://airbnb13.p.rapidapi.com/search-location?location=" +
                         $"{city}&checkin={checkin}&checkout={checkout}&adults={adults.ToString()}&" +
                         $"children=0&infants=0&page=1";
            
            var client = new HttpClient();
            // Create GetItem request
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(uri),
                Headers =
                {
                    { "X-RapidAPI-Key", Constant.ApiKey },
                },
            };
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                HotelModel hotelModel = JsonConvert.DeserializeObject<HotelModel>(body);

                return  hotelModel.results != null? hotelModel: null;
            }
            else
            {
                return null;
            }
        }

    }
}
