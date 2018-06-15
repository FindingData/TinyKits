using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FD.Tiny.DataBuilder.Data;
using System.Collections.Generic;

namespace FD.Tiny.DataBuilder.OracleTest.DbTest
{
    [TestClass]
    public class DbTests : TestBase
    {
        DbClient db;

        const string _testTableName = "T_TEST_1";
        DbTable _testTable;

        [TestInitialize]
        public void Init()
        {
            db = GetInstance();
            if (db.DbMaintenance.IsAnyTable(_testTableName))
                db.DbMaintenance.DropTable(_testTableName);
            _testTable = GetTestTable();
        }

        public DbTable GetTestTable()
        {
            var tb = new DbTable(_testTableName);
            var col = new DbColumn()
            {
                name = "col1",
                data_type = OracleDataType.NVarchar2.ToString(),
                length = 100,
            };
            tb.columns = new List<DbColumn>() { col };
            return tb;
        }
        
        [TestCleanup]
        public void ClearUp()
        {
            if (db.DbMaintenance.IsAnyTable(_testTableName))
            {
                db.DbMaintenance.DropTable(_testTableName);
            }
        }
        
        [TestMethod]
        public void Create_Table_Test()
        {                      
            Assert.IsTrue(db.DbMaintenance.CreateTable(_testTable));
        }

        [TestMethod]
        public void Is_Any_Table_Test()
        {
            db.DbMaintenance.CreateTable(_testTable);
            Assert.IsTrue(db.DbMaintenance.IsAnyTable(_testTableName));
            db.DbMaintenance.DropTable(_testTableName);
            Assert.IsFalse(db.DbMaintenance.IsAnyTable(_testTableName));
        }

        [TestMethod]
        public void Drop_Table_Test()
        {            
            if (!db.DbMaintenance.IsAnyTable(_testTableName))
                db.DbMaintenance.CreateTable(_testTable);
            Assert.IsTrue(db.DbMaintenance.DropTable(_testTableName));

        }

    }
}
