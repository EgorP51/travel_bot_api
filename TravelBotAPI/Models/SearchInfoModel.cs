namespace TravelBotAPI.Models
{
    public class SearchInfoModel
    {
        //https://www.google.com/maps/place/41.89333333,12.48277778
        public string title { get; set; }
        public string url { get; set; }
        public string image { get; set; }
        public string[] summary { get; set; }

    }
}
