using FD.Tiny.ProjectBuilder;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FD.Tiny.ProjectBuilder.UTest
{
    [TestClass()]
    public class SchemaProviderTest: BaseTest
    {       

        [TestMethod()]
        public void GetColumnInfosByTableNameTest()
        {
            var db = GetInstance();
            var columns =  db.DbSchema.GetColumnInfosByTableName("T_PROJECT");
            Assert.IsNotNull(columns);
            foreach (var item in columns)
            {
                TestContext.WriteLine(item.name + ":" + item.comment);
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
