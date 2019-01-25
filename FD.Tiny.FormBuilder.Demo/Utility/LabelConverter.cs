using FD.Tiny.Common.Utility.Json;
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
            var type = j["label_type"].ToObject<LabelType>();
            switch (type)
            {
                case LabelType.control:
                    label = j.ToObject<ControlLabel>(serializer);
                    break;
                case LabelType.variable:
                    label = j.ToObject<VariableLabel>(serializer);
                    break;
                case LabelType.condition:
                    label = j.ToObject<ConditionLabel>(serializer);
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