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
                defaults: new { controller = "Form", action = "Index", id = RouteParameter.Optional }
            );

            
            config.Formatters.JsonFormatter.SerializerSettings.Formatting =
                Newtonsoft.Json.Formatting.Indented;
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add
                (new Newtonsoft.Json.Converters.StringEnumConverter());
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add
             (new LabelConfigConvert());
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add
                (new LabelConverter());
          
            config.Services.Replace(typeof(IContentNegotiator), new JsonContentNegotiator(config.Formatters.JsonFormatter));

        }
    }
}
