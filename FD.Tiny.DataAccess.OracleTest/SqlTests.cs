using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FD.Tiny.DataAccess.OracleTest
{
    [TestClass]
    public class SqlTests : BaseTest
    {
        [TestMethod]
        public void SqlTest()
        {
            var db = GetInstance();
            var x = db.ExecuteCommand("select '@id' as id from t_dictionary d  where id=:id", new { id = 3638 });
            Assert.AreEqual(-1, x);
        }

        [TestMethod]
        public void QueryTest()
        {
            var db = GetInstance();
            var tb = db.GetDataTable("select * from t_dictionary d where dic_type_id=:dic_type_id", new { dic_type_id = 40031 });
            Assert.AreEqual(9, tb.Rows.Count);
        }

        [TestMethod]
        public void UpdateTest()
        {
            var db = GetInstance();
            var x = db.ExecuteCommand("update t_dictionary d " +
                "set dic_par_name ='项目1' where d.dic_par_id=:dic_par_id", new { dic_par_id = 40064001 });
            Assert.AreEqual(1, x);
        }

        [TestMethod]
        public void InssertTest()
        {
            var db = GetInstance();
            var x = db.ExecuteCommand(@"insert into t_dictionary
  (ID, DIC_TYPE_ID, DIC_TYPE_NAME, DIC_PAR_ID, DIC_PAR_NAME, VALID)
values
  (seq_dictionary.nextval,
   :dic_type_id,
   :dic_type_name,
   :dic_par_id,
   :dic_par_name,
   :valid)", new
            {
                dic_type_id = 40064,
                dic_type_name = "消息订阅对象",
                dic_par_id = 40064004,
                dic_par_name = "全局",
                valid = 1
            });
            Assert.AreEqual(1, x);
        }

        [TestMethod]
        public void QueryDataReaderTest()
        {
            var db = GetInstance();
            var reader = db.GetDataReader("select * from t_dictionary d where d.dic_type_id =:dic_type_id",
                new { dic_type_id = 40015 });
            while (reader.Read())
            {
                Console.WriteLine(reader.GetInt32(1).ToString() + " " + reader.GetString(2).ToString());
            }
        }

        [TestMethod]
        public void QueryModelListTest()
        {
            var db = GetInstance();
            var list = db.SqlQuery<DictionaryDTO>("select * from t_dictionary d where d.dic_type_id =:dic_type_id",
                new { dic_type_id = 40015 });
            Assert.IsNotNull(list);
            Assert.AreEqual(7, list.Count());
        }

        [TestMethod]
        public void QueryModelTest()
        {
            var db = GetInstance();
            var model = db.SqlQuerySingle<DictionaryDTO>("select * from t_dictionary d where d.dic_par_id =:dic_par_id",
                new { dic_par_id = 40015001 });
            Assert.IsNotNull(model);
        }

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
