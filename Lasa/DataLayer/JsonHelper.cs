using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Lasa.DataLayer
{
    public class JsonHelper
    {
        public static T ConvertJson<T>(string json)
            where T: new()
        {
            T t = JsonConvert.DeserializeObject<T>(json);
            return t;
        }

        public static string GetJson<T>(T obj)
        {
            string s = JsonConvert.SerializeObject(obj, Formatting.Indented);
            return s;
        }
    }
}