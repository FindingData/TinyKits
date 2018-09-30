using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Tiny.FormBuilder.UTest
{
    public class BaseTest
    {
        public BaseTest()
        {
            AutomapperConfig.Config();
            AutofacExt.InitAutofac();
        }
    }
}
