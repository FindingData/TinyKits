using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FD.Tiny.FormBuilder.Demo.Utility
{
    public class LabelConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Label));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            Label label;
            JObject j = JObject.Load(reader);
            var type = j["label"]["label_type"].ToObject<LabelType>();
            switch (type)
            {
                case LabelType.control:
                    label = j["label"].ToObject<ControlLabel>();
                    break;
                case LabelType.variable:
                    label = j["label"].ToObject<VariableLabel>();
                    break;
                case LabelType.condition:
                    label = j["label"].ToObject<ConditionLabel>();
                    break;
                default:
                    label = null;
                    break;
            }
            return label;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}