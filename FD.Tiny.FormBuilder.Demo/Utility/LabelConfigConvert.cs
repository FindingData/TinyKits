using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FD.Tiny.FormBuilder.Demo.Utility
{
    public class LabelConfigConvert : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(LabelConfig));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            LabelConfig labelConfig;
            JObject j = JObject.Load(reader);
            labelConfig = j.ToObject<LabelConfig>();
            var type = j["data_source"]["data_source_type"].ToObject<DataSourceType>();
            switch (type)
            {
                case DataSourceType.Custom:                    
                    labelConfig.data_source = j["data_source"].ToObject<CustomDataSource>();
                    break;
                case DataSourceType.DataApi:
                    labelConfig.data_source = j["data_source"].ToObject<ApiDataSource>();
                    break;
                case DataSourceType.Dict:
                    labelConfig.data_source = j["data_source"].ToObject<DictSource>();
                    break;
                default:
                    labelConfig = null;
                    break;
            }
            return labelConfig;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}