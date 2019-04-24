using Microsoft.VisualStudio.TestTools.UnitTesting;
using FD.Tiny.Common.Utility.Calc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Tiny.Common.Utility.Calc.Tests
{
    [TestClass()]
    public class CalcStringExpressionTests
    {
        [TestMethod()]
        public void CalcByJsTest()
        {
            var expr = "'新时空' + 2栋";
            var resp = CalcStringExpression.CalcByJs(expr);
            Console.WriteLine(resp);

        }
    }
}