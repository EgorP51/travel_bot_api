using TravelBotAPI.Models;
namespace TravelBotAPI.Clients
{
    public interface IDynamoDbClient
    {
        public Task<InfoFromDBModel> GetDataAsync(string id, string city);
        public Task<string> DeleteDataAsync(string userId, string city);
        public Task<string> PostDataAsync(InfoFromDBModel dBModel);
        public Task<string>  AddItemAsync(string userId,string city,string newRoute);
        public Task<string> DeleteItemAsync(string userId, string city, string newRoute);
    }
}
