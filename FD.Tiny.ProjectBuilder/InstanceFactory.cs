using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FD.Tiny.ProjectBuilder
{
    public class InstanceFactory
    {
        const string _assemblyName = "FD.Tiny.ProjectBuilder";

        static Assembly assembly = Assembly.Load(_assemblyName);

        static Dictionary<string, Type> typeCache = new Dictionary<string, Type>();

        private static string GetClassName(string type, string name)
        {
            return _assemblyName + "." + type + name;
        }

        public static IDbSchema GetDbSchema(DBSetting dBSetting)
        {
            IDbSchema result = CreateInstance<IDbSchema>(GetClassName(dBSetting.DBType.ToString(), "DbSchemaProvider"));
            return result;
        }

        public static T CreateInstance<T>(string className)
        {
            Type type;
            if (typeCache.ContainsKey(className))
            {
                type = typeCache[className];
            }
            else
            {
                lock (typeCache)
                {
                    type = assembly.GetType(className);                  
                    if(type==null)
                    {
                        throw new ArgumentNullException(className + "不存在.");
                    }
                    if (!typeCache.ContainsKey(className))
                    {
                        typeCache.Add(className, type);
                    }
                }
            }
            var result = (T)Activator.CreateInstance(type, true);
            return result;
        }
    }
}
