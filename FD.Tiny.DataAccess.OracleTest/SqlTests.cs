using System;
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
    }
}
