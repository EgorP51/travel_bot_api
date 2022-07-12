namespace TravelBotAPI.Constants
{
    public class Constant
    {
        //Console.WriteLine(Environment.GetEnvironmentVariable("SecretAccessKeyDB"));

        public static readonly string ApiKey = Environment.GetEnvironmentVariable("ApiKey");//"225f8c7ff7mshb7e7f4e4c0c08f4p141e90jsn8eecb2014b0b";
        public static readonly string TableName = Environment.GetEnvironmentVariable("TableName");//"User_Routes";
        public static readonly string AccessKeyDB = Environment.GetEnvironmentVariable("AccessKeyDB"); //"AKIA2OYKR2QKI7DW7LPW";
        public static readonly string SecretAccessKeyDB = Environment.GetEnvironmentVariable("SecretAccessKeyDB");
        //public const string BaseAddress = " ";
    }
}
