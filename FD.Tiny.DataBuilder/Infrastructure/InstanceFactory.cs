using FD.Tiny.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FD.Tiny.DataBuilder
{
    public class InstanceFactory
    {
        const string _assemblyName = "FD.Tiny.DataBuilder";

        static Assembly assembly = Assembly.Load(_assemblyName);

        static Dictionary<string, Type> typeCache = new Dictionary<string, Type>();

        private static string GetClassName(string type, string name)
        {
            return _assemblyName + "." + type + name;
        }


        public static IAdo GetAdo(ConnectionConfig connectionConfig)
        {
            if (connectionConfig.DbType != DBType.Oracle)
            {
                Check.ThrowNotSupportedException("暂未支持其他数据库类型");
            }
            return new OracleProvider(connectionConfig.ConnectionString);
        }


        public static IDbMaintenance GetDbMaintenance(ConnectionConfig currentConnectionConfig)
        {
            IDbMaintenance result = CreateInstance<IDbMaintenance>(GetClassName(currentConnectionConfig.DbType.ToString(), "MaintenacneProvider"));
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
                    Check.ArgumentNullException(type, string.Format(ErrorMessage.ObjNotExist, className));
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
