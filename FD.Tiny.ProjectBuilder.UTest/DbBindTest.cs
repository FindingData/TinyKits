using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FD.Tiny.ProjectBuilder.UTest
{
    [TestClass()]
    public class DbBindTest : BaseTest
    {
        [TestMethod()]
        public void DbTypeTest()
        {
            var db = GetInstance();
            var cName = db.DbBind.GetPropertyTypeName("nvarchar2");
            Assert.AreEqual("string", cName);
        }
    }
}
