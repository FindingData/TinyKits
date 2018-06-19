using FD.Tiny.DataAccess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Tiny.DataBuilder.OracleTest.AdoTest
{
    public class BaseTest
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["OmpdDB"].ConnectionString;

        public static IAdo GetInstance()
        {
            var db = ProviderFactory.GetAdo(new ConnectionConfig() { DbType = DBType.Oracle, ConnectionString = _connectionString });
            return db;
        }
    }
}
