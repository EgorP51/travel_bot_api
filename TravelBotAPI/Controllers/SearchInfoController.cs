using Microsoft.AspNetCore.Mvc;
using TravelBotAPI.Models;
using TravelBotAPI.Clients;
using Amazon.DynamoDBv2.DataModel;

namespace TravelBotAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class SearchInfoController : ControllerBase
    {

        [HttpGet(Name = "SerchInfoCity")]
        public SearchInfoModel Serch(string text)
        {
            SearchInfoClient searchInfoClient = new SearchInfoClient();
            return searchInfoClient.GetCityInfoAsync(text).Result;
        }
    }
    

}
