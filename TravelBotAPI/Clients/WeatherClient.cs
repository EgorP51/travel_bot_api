using TravelBotAPI.Models;
using Newtonsoft.Json;
using TravelBotAPI.Constants;

namespace TravelBotAPI.Clients
{
    public class WeatherClient
    {
        public async Task<WeatherModel?> GetWeatherAsync(string city)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://yahoo-weather5.p.rapidapi.com/weather?location={city}&format=json&u=c"),
                //It is possible to change the weather unit, in my case it is Celsius
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
                WeatherModel weatherModel = JsonConvert.DeserializeObject<WeatherModel>(body);

                return weatherModel.forecasts != null && weatherModel.location != null? weatherModel: null;
            }
            else
            {
                return null;
            }
        }
    }
}
