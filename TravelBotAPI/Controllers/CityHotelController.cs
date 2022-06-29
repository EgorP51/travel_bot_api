using Microsoft.AspNetCore.Mvc;
using TravelBotAPI.Models;
using TravelBotAPI.Clients;


namespace TravelBotAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CityHotelController : ControllerBase
    {
        [HttpGet(Name = "CityHotel")]
        public HotelModel Hotel(string city, string checkin, string checkout, int adults)
        {
            HotelClient client = new HotelClient();
            return client.GetHotelsAsync(city,checkin,checkout,adults).Result;

        }
    }
}
