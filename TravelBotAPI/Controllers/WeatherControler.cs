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
            return weatherClient.GetWeatherAsync(city).Result;
            Console.WriteLine();
        }
    }
   
}
