using Autofac;
using Autofac.Extras.DynamicProxy;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using FD.Tiny.Common.Utility.Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace FD.Tiny.FormBuilder.Demo
{
    public static class AutofacExt
    {
        private static IContainer _container;

        public static void InitAutofac()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<LoggingAroundAdvice>();

            //注册数据库基础操作和工作单元
            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IRepository<>)).PropertiesAutowired();

            //builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).PropertiesAutowired();
            var app = Assembly.Load("FD.Tiny.FormBuilder");            
            builder.RegisterAssemblyTypes(app).Where(d => d.Name.EndsWith("Service"))               
               .EnableClassInterceptors()
              .InterceptedBy(typeof(LoggingAroundAdvice))
              .PropertiesAutowired();

            var controller = Assembly.Load("FD.Tiny.FormBuilder.Demo");
            builder.RegisterControllers(controller)
                .EnableClassInterceptors()
                .InterceptedBy(typeof(LoggingAroundAdvice))
                .PropertiesAutowired();

            builder.RegisterApiControllers(controller).PropertiesAutowired();

            // 注册所有的Attribute
            builder.RegisterFilterProvider();

            // Set the dependency resolver to be Autofac.
            _container = builder.Build();

            HttpConfiguration config = GlobalConfiguration.Configuration;
            config.DependencyResolver = new AutofacWebApiDependencyResolver(_container);

            DependencyResolver.SetResolver(new AutofacDependencyResolver(_container));
        }

        /// <summary>
        /// 从容器中获取对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static T GetFromFac<T>()
        {
            return _container.Resolve<T>();
        }
    }
}