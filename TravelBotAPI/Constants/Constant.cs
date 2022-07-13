namespace TravelBotAPI.Constants
{
    public class Constant
    {
        public static readonly string ApiKey = Environment.GetEnvironmentVariable("ApiKey");
        public static readonly string TableName = Environment.GetEnvironmentVariable("TableName");
        public static readonly string AccessKeyDB = Environment.GetEnvironmentVariable("AccessKeyDB");
        public static readonly string SecretAccessKeyDB = Environment.GetEnvironmentVariable("SecretAccessKeyDB");
    }
}
