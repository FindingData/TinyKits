using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Tiny.Common.Utility.Json
{
    public class JsonHelper
    {
        private static JsonHelper _jsonHelper = new JsonHelper();
        public static JsonHelper Instance { get { return _jsonHelper; } }

        private static JsonSerializerSettings _setting = new JsonSerializerSettings();
        public static JsonSerializerSettings Setting{ get { return _setting; } }

        static JsonHelper()
        {
            Setting.NullValueHandling = NullValueHandling.Ignore;
            Setting.Converters.Add(new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" });
            Setting.Converters.Add(new StringEnumConverter());
        }

        public string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, _setting);
        }

        public string SerializeByConverter(object obj, params JsonConverter[] converters)
        {
            return JsonConvert.SerializeObject(obj, converters);
        }

        public T Deserialize<T>(string input)
        {
            return JsonConvert.DeserializeObject<T>(input,_setting);
        }

        public T DeserializeByConverter<T>(string input, params JsonConverter[] converter)
        {
            return JsonConvert.DeserializeObject<T>(input, converter);
        }

        public T DeserializeBySetting<T>(string input, JsonSerializerSettings settings)
        {
            return JsonConvert.DeserializeObject<T>(input, settings);
        }

        private object NullToEmpty(object obj)
        {
            return null;
        }
    }
}
