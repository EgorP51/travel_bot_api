using TravelBotAPI.Models;
using Newtonsoft.Json;
using TravelBotAPI.Constants;

namespace TravelBotAPI.Clients
{
    public class SearchInfoClient
    {
        public SearchInfoClient()
        {

        }

        public async Task<SearchInfoModel> GetCityInfoAsync(string city)
        {
            var client = new HttpClient(); // Wiki
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://wiki-briefs.p.rapidapi.com/search?q={city}&topk=3"),// temp
                Headers =
                {
                    { "X-RapidAPI-Key", Constant.apiKey },
                    { "X-RapidAPI-Host", "wiki-briefs.p.rapidapi.com" },
                },
            };
            var response = await client.SendAsync(request);
            if(response.IsSuccessStatusCode)
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                SearchInfoModel searchInfoModel = JsonConvert.DeserializeObject<SearchInfoModel>(body);
                if(searchInfoModel != null)
                {
                    return searchInfoModel;
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
