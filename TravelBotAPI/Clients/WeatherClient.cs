using TravelBotAPI.Models;
using Newtonsoft.Json;
using TravelBotAPI.Constants;

namespace TravelBotAPI.Clients
{
    public class WeatherClient
    {

        public async Task<WeatherModel> GetWeatherAsync(string city)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://yahoo-weather5.p.rapidapi.com/weather?location={city}&format=json&u=c"),
                Headers =
                {
                    { "X-RapidAPI-Host", "yahoo-weather5.p.rapidapi.com" },
                    { "X-RapidAPI-Key", Constant.apiKey },
                },
            };
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                WeatherModel weatherModel = JsonConvert.DeserializeObject<WeatherModel>(body);
                if(weatherModel.forecasts != null && weatherModel.location != null)
                {
                    return weatherModel;
                }
                else
                {
                    Console.WriteLine("null1");
                    return null;
                }
            }
            else
            {
                Console.WriteLine("null2");
                return null;
            }
        }
    }
}
