using Microsoft.AspNetCore.Mvc;
using TravelBotAPI.Models;
using TravelBotAPI.Clients;


namespace TravelBotAPI.Controllers
{ 
    [ApiController]
    [Route("[controller]")]
    public class WeatherControler : ControllerBase
    {
        [HttpGet(Name = "WeatherCity")]
        public WeatherModel Weather(string city)
        {
            WeatherClient weatherClient = new WeatherClient();
            try
            {
                return weatherClient.GetWeatherAsync(city).Result;

            }catch (Exception ex)
            {
                return null;
            }
        }
    }
   
}
