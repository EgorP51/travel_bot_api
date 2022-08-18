using Microsoft.AspNetCore.Mvc;
using TravelBotAPI.Models;
using TravelBotAPI.Clients;

namespace TravelBotAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class SearchInfoController : ControllerBase
    {

        [HttpGet(Name = "SerchInfoCity")]
        public SearchInfoModel? Serch(string text)
        {
            SearchInfoClient searchInfoClient = new SearchInfoClient();
            try
            {
                return searchInfoClient.GetCityInfoAsync(text).Result;

            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;    
            }
        }
    }
    

}
