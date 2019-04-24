using Microsoft.VisualStudio.TestTools.UnitTesting;
using FD.Tiny.FormBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FD.Tiny.FormBuilder.UTest;
using FD.Tiny.Common.Utility.Json;

namespace FD.Tiny.FormBuilder.Tests
{
    [TestClass()]
    public class LabelServiceTests : BaseTest
    {

        private LabelService _labelService;


        public LabelServiceTests()
        {
            _labelService = AutofacExt.GetFromFac<LabelService>();
        }


    }
}