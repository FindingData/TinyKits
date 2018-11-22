using Microsoft.VisualStudio.TestTools.UnitTesting;
using FD.Tiny.FormBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FD.Tiny.FormBuilder.UTest;
using FD.Tiny.FormBuilder.Demo;

namespace FD.Tiny.FormBuilder.Tests
{
    [TestClass()]
    public class DictServiceTests : BaseTest
    {
        private DictService _dictService;

        public DictServiceTests()
        {
            _dictService = AutofacExt.GetFromFac<DictService>();
        }


        [TestMethod()]
        public void GetDictListTest()
        {
            //var dictList = _dictService.GetDictList();
            //Assert.Fail();
        }

        [TestMethod()]
        public void GetAllDictListTest()
        {
            var dictList = _dictService.GetAllDictList();
            Assert.IsNotNull(dictList);
            
        }
    }
}