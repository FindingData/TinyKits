﻿using FD.Tiny.Common.Utility.JsonSubTypes;
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

            //序列化配置
            JsonConfig.Config();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);            
            BundleConfig.RegisterBundles(BundleTable.Bundles);                                          
        }
    }
}
