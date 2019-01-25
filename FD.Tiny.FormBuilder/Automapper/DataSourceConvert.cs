using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Tiny.FormBuilder
{
    public class DataSourceConvert : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(DataSource));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            DataSource dataSource;
            JObject j = JObject.Load(reader);
            var type = j["data_source_type"].ToObject<DataSourceType>();
            switch (type)
            {
                case DataSourceType.Custom:
                    dataSource = j.ToObject<CustomDataSource>(serializer);
                    break;
                case DataSourceType.DataApi:
                    dataSource = j.ToObject<ApiDataSource>(serializer);
                    break;
                case DataSourceType.Dict:
                    dataSource = j.ToObject<DictSource>(serializer);
                    break;
                default:
                    dataSource = null;
                    break;
            }
            return dataSource;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
