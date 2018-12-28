using FD.Tiny.Common.Utility.Json;
using FD.Tiny.Common.Utility.JsonSubTypes;
using FD.Tiny.FormBuilder.Demo.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace FD.Tiny.FormBuilder.Demo
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { controller = "Data", action = "Index", id = RouteParameter.Optional }
            );

            
            config.Formatters.JsonFormatter.SerializerSettings.Formatting =
                Newtonsoft.Json.Formatting.Indented;
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add
                (new Newtonsoft.Json.Converters.StringEnumConverter());
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add
                (new LabelConverter());
            //config.Formatters.JsonFormatter.SerializerSettings.Converters.Add
            //    (JsonSubtypesConverterBuilder
            //.Of(typeof(Label), "label_type") // type property is only defined here
            //.RegisterSubtype(typeof(ControlLabel), LabelType.control)
            //.RegisterSubtype(typeof(VariableLabel), LabelType.variable)
            //.RegisterSubtype(typeof(ConditionLabel), LabelType.condition)
            //.SerializeDiscriminatorProperty() // ask to serialize the type property
            //.Build());

            var jsonFormatter = new JsonMediaTypeFormatter();
            jsonFormatter.SerializerSettings.Converters.Add(new LabelConverter());
            jsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            jsonFormatter.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());

            config.Services.Replace(typeof(IContentNegotiator), new JsonContentNegotiator(jsonFormatter));

        }
    }
}
