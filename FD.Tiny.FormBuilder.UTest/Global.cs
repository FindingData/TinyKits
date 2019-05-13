using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Tiny.FormBuilder.UTest
{
    [TestClass()]
    public sealed class Global
    {
        [AssemblyInitialize()]
        public static void AssemblyInit(TestContext context)
        {
            AutomapperExt.Config();
            AutofacExt.InitAutofac();
        }
    }
}