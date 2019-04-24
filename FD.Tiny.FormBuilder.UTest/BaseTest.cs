using FD.Tiny.FormBuilder.UTest.Init;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Tiny.FormBuilder.UTest
{
    public class BaseTest
    {
        public Api_Init ApiInit { get; set; }

        public Data_Init DataInit { get; set; }

        public Database_Init DatabaseInit { get; set; }

        public Form_Init FormInit { get; set; }

        public BaseTest()
        {
            AutomapperExt.Config();
            AutofacExt.InitAutofac();          
        }      

        [TestInitialize]
        public void Init()
        {
            ApiInit.Inits();
            DataInit.Inits();
            DatabaseInit.Inits();
            FormInit.Inits();
        }

        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，该上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
    }
}
