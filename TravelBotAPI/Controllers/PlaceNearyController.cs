using Microsoft.AspNetCore.Mvc;
using TravelBotAPI.Models;
using TravelBotAPI.Clients;

namespace TravelBotAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlaceNearyController : ControllerBase
    {
        [HttpGet(Name = "PlaceNearyCity")]
        public PlacesNearbyInfoModel? PlaceNeary(string lat, string lng, string type)
        {
            PlacesNearbyInfoClient placesNearbyInfoClient = new PlacesNearbyInfoClient();
            try
            {
                return placesNearbyInfoClient.GetInfoAsync(lat, lng, type).Result;

            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
    }
}
