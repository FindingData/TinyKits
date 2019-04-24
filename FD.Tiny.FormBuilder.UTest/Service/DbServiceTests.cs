using System;
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

    }
}
