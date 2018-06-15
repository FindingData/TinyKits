using FD.Tiny.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Tiny.DataBuilder.OracleTest.DbTest
{
    [TestClass]
    public class TestBase
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["OmpdDB"].ConnectionString;

        public DbClient GetInstance()
        {
            var db = new DbClient(new ConnectionConfig() { ConnectionString = _connectionString, DbType = DBType.Oracle });
            return db;
        }
    }
}
