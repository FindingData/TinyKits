using FD.Tiny.ProjectBuilder;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace FD.Tiny.ProjectBuilder.UTest
{
    [TestClass()]
    public class SchemaProviderTest: BaseTest
    {       

        [TestMethod()]
        public void GetColumnInfosByTableNameTest()
        {
            var db = GetInstance();
            var columns =  db.DbSchema.GetColumnInfosByTableName("T_PROPERTY");
           // Assert.AreEqual(columns.Count(), 18);
            foreach (var item in columns)
            {
                //var typeName = db.DbBind.GetPropertyTypeName(item.data_type);
                TestContext.WriteLine(item.name + ":" + item.data_type);
            }            
        }

        [TestMethod()]
        public void GetTableInfoListTest()
        {
            var db = GetInstance();
            var tables = db.DbSchema.GetTableInfoList();
            Assert.IsNotNull(tables);
            foreach (var item in tables)
            {
                TestContext.WriteLine(item.name + ":" + item.comment);
            }
        }
    }
}
