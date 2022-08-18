using TravelBotAPI.Models;
using Newtonsoft.Json;
using TravelBotAPI.Constants;

namespace TravelBotAPI.Clients
{
    public class SearchInfoClient
    {
        public async Task<SearchInfoModel?> GetCityInfoAsync(string city)
        {
            var client = new HttpClient(); // Wiki
            // Create GetItem request
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://wiki-briefs.p.rapidapi.com/search?q={city}&topk=3"), 
                //It is possible to change the number of pages, in my case there are 3
                Headers =
                {
                    { "X-RapidAPI-Key", Constant.ApiKey }
                },
            };
            var response = await client.SendAsync(request);

            if(response.IsSuccessStatusCode)
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                SearchInfoModel searchInfoModel = JsonConvert.DeserializeObject<SearchInfoModel>(body);

                return searchInfoModel != null ? searchInfoModel : null;
            }
            else
            {
                return null;
            }
        }
    }
   
}
