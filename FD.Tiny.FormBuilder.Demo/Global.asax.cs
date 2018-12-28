using FD.Tiny.Common.Utility.JsonSubTypes;
using FD.Tiny.FormBuilder.Demo.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace FD.Tiny.FormBuilder.Demo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //注册容器
            AutofacExt.InitAutofac();

            //配置映射
            AutomapperConfig.Config();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);            
            BundleConfig.RegisterBundles(BundleTable.Bundles);

             
         
         

            var config = GlobalConfiguration.Configuration;

            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new LabelConverter());
            
            //var jsonFormatter = new JsonMediaTypeFormatter();
            //jsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            //jsonFormatter.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
            //jsonFormatter.SerializerSettings.Converters.Add(JsonSubtypesConverterBuilder
            //.Of(typeof(Label), "label_type") // type property is only defined here
            //.RegisterSubtype(typeof(ControlLabel), LabelType.control)
            //.RegisterSubtype(typeof(VariableLabel), LabelType.variable)
            //.RegisterSubtype(typeof(ConditionLabel), LabelType.condition)
            //.SerializeDiscriminatorProperty() // ask to serialize the type property
            //.Build());
            //config.Formatters.Remove(config.Formatters.JsonFormatter);
            //config.Formatters.Insert(0, jsonFormatter);
        }
    }
}
