using FD.Tiny.DataBuilder.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Tiny.DataBuilder.OracleTest.AdoTest
{
    [TestClass]
    public class SqlTests : BaseTest
    {
        [TestMethod]
        public void QueryDbTest()
        {
            var db = GetInstance();
            var tb = db.GetDataTable(GetTableInfoSql);
            var list = db.SqlQuery<DbTable>(GetTableInfoSql);
            Assert.IsNotNull(list);
        }

        const string GetTableInfoSql = @"SELECT  table_name name from user_tables where
                        table_name!='HELP' 
                        AND table_name NOT LIKE '%$%'
                        AND table_name NOT LIKE 'LOGMNRC_%'
                        AND table_name!='LOGMNRP_CTAS_PART_MAP'
                        AND table_name!='LOGMNR_LOGMNR_BUILDLOG'
                        AND table_name!='SQLPLUS_PRODUCT_PROFILE'";
    }
}
