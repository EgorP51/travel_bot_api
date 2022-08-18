using Microsoft.AspNetCore.Mvc;
using TravelBotAPI.Models;
using TravelBotAPI.Clients;

namespace TravelBotAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InfoFromDBController: ControllerBase
    {
        private readonly ILogger<InfoFromDBController> _logger;
        private readonly IDynamoDbClient _dynamoDbClient;

        public InfoFromDBController(
            ILogger<InfoFromDBController> logger,
            IDynamoDbClient dynamoDbClient)
        {
            _logger = logger;
            _dynamoDbClient = dynamoDbClient;
        }

        [HttpGet("get")]
        public async Task<InfoFromDBModel> GetRoutesFromDB(string id, string city)
        {
            var result = _dynamoDbClient.GetData(id, city);
            if (result == null)
            {
                return null;
            }
            else
            { 
                return await result;
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddRoute([FromBody] InfoFromDBModel infoFromDBModel)
        {
            var data = new InfoFromDBModel
            {
                City = infoFromDBModel.City,
                UserId = infoFromDBModel.UserId,
                NewValue = infoFromDBModel.NewValue
            };
             var result = await _dynamoDbClient.PostData(data);
            if(result != "Ok")
            {
                return BadRequest("Cannot insert value to database");
            }
            return Ok("Value has successfully added to database");
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(string userId, string city)
        {
            var result = await _dynamoDbClient.DeleteData(userId,city);
            if( result != "Ok")
            {
                return BadRequest("Cannot delete value to database");
            }
            //Console.WriteLine("Value has successfully delete DB");
            return Ok("Value has successfully delete database");
        }

        [HttpPut("addItem")]
        public async Task<IActionResult> UpdateADD([FromBody] PutBody putBody)
        {
            var result = await _dynamoDbClient.AddItem(putBody.UserId, putBody.City, putBody.NewRoute);
            
            if(result != "Ok")
            {
                return BadRequest("Cannot insert value to database");
            }
            return Ok("Item value successfully added to");
        }

        [HttpPut("deleteItem")]
        public async Task<IActionResult> UpdateDelete([FromBody] PutBody putBody)
        {
            var result = await _dynamoDbClient.DeleteItem(putBody.UserId, putBody.City, putBody.NewRoute);
            
            if (result != "Ok")
            {
                return BadRequest("Can't remove value from database");
            }
            return Ok("Item value successfully removed from database");
        }
    }
   
}
