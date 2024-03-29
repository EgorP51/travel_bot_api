﻿using Amazon.DynamoDBv2.Model;
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

}