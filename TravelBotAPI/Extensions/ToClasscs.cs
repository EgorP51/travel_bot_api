using Amazon.DynamoDBv2.Model;
using System.Reflection;

namespace TravelBotAPI.Extensions
{
    public static class ToClasscs
    {
        public static T ToClass<T>(this Dictionary<string, AttributeValue> dict)
        {
            var type = typeof(T);
            var obj = Activator.CreateInstance(type);

            foreach (var kv in dict)
            {
                var property = type.GetProperty(kv.Key);

                if (property != null)
                {
                    if (!string.IsNullOrEmpty(kv.Value.S))
                    {
                        property.SetValue(obj, kv.Value.S);
                    }
                    else if (!string.IsNullOrEmpty(kv.Value.N))
                    {
                        property.SetValue(obj, int.Parse(kv.Value.N));
                    }
                    else if (kv.Value.SS.Count != 0 && kv.Value.SS != null)
                    {
                        property.SetValue(obj, (List<string>)kv.Value.SS);
                    }
                }
            }
            return (T)obj;
        }
    }

    //public static T ToClass<T>(Dictionary<string, AttributeValue> resultItem) where T : new()
    //{
    //    var resultDictionary = new Dictionary<string, object>();

    //    Type type = typeof(T);
    //    T ret = new T();

    //    foreach (KeyValuePair<string, AttributeValue> p in resultItem)
    //        if (p.Value != null)
    //            foreach (PropertyInfo prop in p.Value.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
    //                if (prop.GetValue(p.Value, null) != null)
    //                {
    //                    if (prop.Name == "S")
    //                        type.GetProperty(p.Key).SetValue(ret, prop.GetValue(p.Value, null), null);

    //                    if (prop.Name == "SS")
    //                        type.GetProperty(p.Key).SetValue(ret, (List<string>)prop.GetValue(p.Value, null), null);

    //                    if (prop.Name == "N")
    //                        type.GetProperty(p.Key).SetValue(ret, Convert.ToInt32(prop.GetValue(p.Value, null)), null);

    //                    // TODO: add some other types. Too tired tonight
    //                }
    //    return ret;
    //}

}
