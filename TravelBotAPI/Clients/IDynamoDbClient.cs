using Amazon.DynamoDBv2;
using TravelBotAPI.Models;
namespace TravelBotAPI.Clients
{
    public interface IDynamoDbClient
    {
        public Task<InfoFromDBModel> GetData(string id, string city);
        public Task<string> DeleteData(string userId, string city);
        public Task<string> PostData(InfoFromDBModel dBModel);
        public Task<string>  UpdateDataAddItem(string userId,string city,string newRoute);
        public Task<string> UpdateDataDeleteItem(string userId, string city, string newRoute);
    }
}
