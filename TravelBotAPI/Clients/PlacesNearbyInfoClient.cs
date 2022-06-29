using TravelBotAPI.Constants;
using TravelBotAPI.Models;
using Newtonsoft.Json;


namespace TravelBotAPI.Clients
{
    public class PlacesNearbyInfoClient
    {
        public async Task<PlacesNearbyInfoModel> GetInfoAsync(string lat,string lng,string type)
        {
			string url = $"https://trueway-places.p.rapidapi.com/FindPlacesNearby?location={lat}%2C{lng}&type={type}&radius=10000&language=en";
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(url),
				Headers =
	            {
		            { "X-RapidAPI-Key", Constant.ApiKey },
		            { "X-RapidAPI-Host", "trueway-places.p.rapidapi.com" },
	            },
			};
			var response = await client.SendAsync(request);
			if (response.IsSuccessStatusCode)
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				PlacesNearbyInfoModel placesNearbyInfoModel = JsonConvert.DeserializeObject<PlacesNearbyInfoModel>(body);
				if(placesNearbyInfoModel.results != null)
                {
					return placesNearbyInfoModel;
                }
                else
                {
					return null;
                }
			}
            else
			{
				return null;
            }
		}
    }
}
