using Microsoft.AspNetCore.Mvc;
using TravelBotAPI.Models;
using TravelBotAPI.Clients;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.Model;
using Amazon.DynamoDBv2;
using TravelBotAPI.Constants;
using TravelBotAPI.Extensions;
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
        public async Task<InfoFromDBModel> GetRoutesFromDB(string id = "783450273", string city = "London")
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
            if(result == false)
            {
                return BadRequest("Cannot insert value to database");
            }
            return Ok("Value has successfully added to DB");
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(string userId, string city)
        {
            var result = await _dynamoDbClient.DeleteData(userId,city);
            if( result == false)
            {
                return BadRequest("Cannot delete value to database");
            }
            Console.WriteLine("Value has successfully delete DB");
            return Ok("Value has successfully delete DB");
        }

        [HttpPut("addItem")]
        public async Task<IActionResult> UpdateADD([FromBody] PutBody putBody)
        {

            var result = await _dynamoDbClient.UpdateDataAddItem(putBody.UserId, putBody.City, putBody.NewRoute);

            return Ok(result);
        }

        [HttpPut("deleteItem")]
        public async Task<IActionResult> UpdateDelete([FromBody] PutBody putBody)
        {

            var result = await _dynamoDbClient.UpdateDataDeleteItem(putBody.UserId, putBody.City, putBody.NewRoute);

            return Ok(result);
        }
    }
    public class PutBody
    {
        public string UserId { get; set; }
        public string City { get; set; }
        public string NewRoute { get; set; }
    }
    public class DeleteBody
    {
        public string UserId { get; set; }
        public string City { get; set; }
    }

}
