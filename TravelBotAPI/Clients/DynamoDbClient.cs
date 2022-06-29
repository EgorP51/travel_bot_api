using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using TravelBotAPI.Clients;
using TravelBotAPI.Constants;
using TravelBotAPI.Extensions;
using TravelBotAPI.Models;
using TravelBotAPI.Clients;
using Amazon.Runtime;

namespace TravelBotAPI.Clients
{
    public class DynamoDbClient : IDynamoDbClient
    {
        private string _tableName;
        private readonly IAmazonDynamoDB _dynamoDb;
        public DynamoDbClient(IAmazonDynamoDB dynamoDB)
        {
            _tableName = Constant.TableName;
            _dynamoDb = dynamoDB;
        } 
        
        public async Task<string> UpdateDataAddItem(string userId, string city,string newRoute)
        {
            Dictionary<string, AttributeValue> key = new Dictionary<string, AttributeValue>
            {
                { "UserId", new AttributeValue { S = userId } },
                { "City", new AttributeValue { S = city } }
            };

            // Define attribute updates
            Dictionary<string, AttributeValueUpdate> updates = new Dictionary<string, AttributeValueUpdate>();
            // Update item's Setting attribute
            updates["NewValue"] = new AttributeValueUpdate()
            {
                Action = AttributeAction.ADD,
                Value = new AttributeValue { SS = new List<string> { newRoute } }
            };

            // Create UpdateItem request
            UpdateItemRequest request = new UpdateItemRequest
            {
                TableName =_tableName,
                Key = key,
                AttributeUpdates = updates
            };

            try
            {
                await _dynamoDb.UpdateItemAsync(request);
                return "OK";
            }
            catch (Exception ex)
            {
                return "Here is your error!\n" + ex;
            }


        }
        public async Task<string> UpdateDataDeleteItem(string userId, string city, string newRoute)
        {
            Dictionary<string, AttributeValue> key = new Dictionary<string, AttributeValue>
            {
                { "UserId", new AttributeValue { S = userId } },
                { "City", new AttributeValue { S = city } }
            };

            Dictionary<string, AttributeValueUpdate> updates = new Dictionary<string, AttributeValueUpdate>();
            updates["NewValue"] = new AttributeValueUpdate()
            {
                Action = AttributeAction.DELETE,
                Value = new AttributeValue { SS = new List<string> { newRoute } }
            };

            UpdateItemRequest request = new UpdateItemRequest
            {
                TableName = _tableName,
                Key = key,
                AttributeUpdates = updates
            };

            try
            {
                await _dynamoDb.UpdateItemAsync(request);
                return "OK";
            }
            catch (Exception ex)
            {
                return "Here is your error!\n" + ex;
            }


        }
        public async Task<string> DeleteData(string userId, string city)
        {
            var request = new DeleteItemRequest
            {
                TableName = _tableName,
                Key = new Dictionary<string, AttributeValue>()
                {
                    { "UserId", new AttributeValue { S = userId } },
                    {"City", new AttributeValue{ S = city } }
                },

            };
            
            try
            {
                var response = _dynamoDb.DeleteItemAsync(request);
                return "Ok";

            }catch (Exception ex)
            {
                return "Here is your error!\n" + ex;
            }
           
        }
       
        public async Task<InfoFromDBModel> GetData(string id, string city)
        {
            var item = new GetItemRequest
            {
                TableName = _tableName,
                Key = new Dictionary<string, AttributeValue>
                {
                    {"UserId",new AttributeValue{S = id }},
                    {"City", new AttributeValue{S = city}}
                }
            };
            var response = await _dynamoDb.GetItemAsync(item);
            var result = response.Item.ToClass<InfoFromDBModel>();
            return result;
        }

        public async Task<string> PostData(InfoFromDBModel dBModel)
        {
            var request = new PutItemRequest
            {
                TableName = _tableName,
                Item = new Dictionary<string, AttributeValue>()
                {
                    { "UserId", new AttributeValue { S = dBModel.UserId } },
                    { "City", new AttributeValue { S = dBModel.City } },
                    { "NewValue", new AttributeValue { SS = dBModel.NewValue } }
                }
            };   

            try
            {
                var response = await _dynamoDb.PutItemAsync(request);
                return "Ok";

            }catch(Exception ex)
            {
                return "Here is your error!\n" + ex;
            }
        }
    }
}
