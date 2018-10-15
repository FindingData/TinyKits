using System;
using FD.Tiny.FormBuilder.Demo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FD.Tiny.FormBuilder.UTest
{
    [TestClass]
    public class DbServiceTests:BaseTest
    {

        DbTableService _dbTableService;
        DbColumnService _dbColService;

        public DbServiceTests()
        {
            _dbTableService = AutofacExt.GetFromFac<DbTableService>();
            _dbColService = AutofacExt.GetFromFac<DbColumnService>();
        }

        [TestInitialize]
        public void TestInitialize()
        {
         
        }

        [TestMethod]
        public void AddDbTableTest()
        {
            var table = new DbTable();
            table.schema_name = "oa";
            table.table_name = "t_api";
            table.table_name_chs = "接口表";
            _dbTableService.AddDbTable(table, 1);
        }

        [TestMethod]
        public void UpdateDbTableTest()
        {
            var table = _dbTableService.GetTable(1);
            table.table_name_chs = "接口服务表";
            _dbTableService.SaveDbTable(table, 1);
            Assert.AreEqual(table.table_id, 1);
        }

        [TestMethod]
        public void AddDbColumnTest()
        {
            var col = new DbColumn();
            col.column_name = "api_name";
            col.table_id = 2;
            col.column_name_chs = "接口名称";
            col.length = 100;
            col.scale = 8;
            col.data_type = DataType.String;
            col.precision = 10;
            var colId = _dbColService.AddDbColumn(col, 1);
            Console.WriteLine(colId);
        }

        [TestMethod]
        public void GetDbColumnTest()
        {
            var col = _dbColService.GetDbColumn(2);
            Console.WriteLine(col.column_name);
            Console.WriteLine(col.column_name_chs);
        }

    }
}
