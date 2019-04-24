using Microsoft.VisualStudio.TestTools.UnitTesting;
using FD.Tiny.FormBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FD.Tiny.FormBuilder.UTest;

namespace FD.Tiny.FormBuilder.Tests
{
    [TestClass()]
    public class FormServiceTests : BaseTest
    {
        private FormService _formService;
        //private FormVariableService _formVariableService;

        public FormServiceTests()
        {
            _formService = AutofacExt.GetFromFac<FormService>();
            //  _formVariableService = AutofacExt.GetFromFac<FormVariableService>();
        }


                

        
    }
}