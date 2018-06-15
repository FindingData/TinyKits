using FD.Tiny.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Tiny.DataBuilder
{
    internal class DependencyManagement
    {                        
        private static bool IsTryOracle = false;

        internal static void TryOracle(string connectionString)
        {
            if (!IsTryOracle)
            {
                try
                {
                    OracleProvider db = new OracleProvider(connectionString);
                    var conn = db.GetAdapter();
                    IsTryOracle = true;
                }
                catch(Exception ex)
                {
                    var message = ErrorMessage.GetThrowMessage(
                     "You need to refer to Oracle.ManagedDataAccess.dll",
                     "需要引用ManagedDataAccess.dll，请在Nuget安装最新稳定版本,如果有版本兼容问题请先删除原有引用");
                    throw new Exception(message);
                }
            }
        }
    }
}
