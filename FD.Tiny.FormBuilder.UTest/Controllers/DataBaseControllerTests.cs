using Microsoft.VisualStudio.TestTools.UnitTesting;
using FD.Tiny.FormBuilder.Demo.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FD.Tiny.FormBuilder.UTest;
using System.Web.Mvc;
using FD.Tiny.Common.Utility.PageHeler;

namespace FD.Tiny.FormBuilder.Demo.Controllers.Tests
{
    [TestClass()]
    public class DataBaseControllerTests: BaseTest
    {
        DataBaseController _controller;

        public DataBaseControllerTests()
        {
            _controller = new DataBaseController(AutofacExt.GetFromFac<DbTableService>(), AutofacExt.GetFromFac<DbColumnService>());
        }

        [TestMethod()]
        public void DataBaseControllerTest()
        {
            var result = _controller.Index("") as JsonResult;
            var data = (BaseResponse)result.Data;
            var list = data.Result;

        }
    }
}