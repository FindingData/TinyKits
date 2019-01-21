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
            bool result = typeof(DataSource).IsAssignableFrom(objectType);
            return result;            
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            DataSource dataSource = new DataSource();
            JObject j = JObject.Load(reader);
            if (j.ContainsKey("data_source_type"))
            {
                var type = j["data_source_type"].ToObject<DataSourceType>();
                switch (type)
                {
                    case DataSourceType.Custom:
                        dataSource = j.ToObject<CustomDataSource>();
                        break;
                    case DataSourceType.DataApi:
                        dataSource = j.ToObject<ApiDataSource>();
                        break;
                    case DataSourceType.Dict:
                        dataSource = j.ToObject<DictSource>();
                        break;
                    default:
                        dataSource = new DataSource();
                        break;
                }
            }        
            return dataSource;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
