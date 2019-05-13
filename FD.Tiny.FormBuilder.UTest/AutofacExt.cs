using Autofac;
using Autofac.Extras.DynamicProxy;
using FD.Tiny.Common.Utility.Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FD.Tiny.FormBuilder.UTest
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
            
            var init = Assembly.Load("FD.Tiny.FormBuilder.UTest");
            builder.RegisterAssemblyTypes(init).Where(d => d.Name.EndsWith("Init"))
               .EnableClassInterceptors()
              .InterceptedBy(typeof(LoggingAroundAdvice))
              .PropertiesAutowired();

            var test = Assembly.Load("FD.Tiny.FormBuilder.UTest");
            builder.RegisterAssemblyTypes(test).Where(d => d.Name.EndsWith("Test"))
               .EnableClassInterceptors()
              .InterceptedBy(typeof(LoggingAroundAdvice))
              .PropertiesAutowired();            

            // Set the dependency resolver to be Autofac.
            _container = builder.Build();
            
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
