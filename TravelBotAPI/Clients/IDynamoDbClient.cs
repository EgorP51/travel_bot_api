using Amazon.DynamoDBv2;
using TravelBotAPI.Models;
namespace TravelBotAPI.Clients
{
    public interface IDynamoDbClient
    {
        public Task<InfoFromDBModel> GetData(string id, string city);
        public Task<string> DeleteData(string userId, string city);
        public Task<string> PostData(InfoFromDBModel dBModel);
        public Task<string>  AddItem(string userId,string city,string newRoute);
        public Task<string> DeleteItem(string userId, string city, string newRoute);
    }
}
