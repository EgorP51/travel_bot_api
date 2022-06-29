namespace TravelBotAPI.Models
{
    public class WeatherModel
    {
        public Location location { get; set; }
        public Forecasts[] forecasts { get; set; }
    }
    public class Location
    {
        public string city { get; set; }
        public string country { get; set; }
        public string lat { get; set; }
        public string @long { get; set; }
    }
    public class Forecasts
    {
        public string day { get; set; }
        public string low { get; set; }
        public string high { get; set; }
        public string text { get; set; }
    }
}
