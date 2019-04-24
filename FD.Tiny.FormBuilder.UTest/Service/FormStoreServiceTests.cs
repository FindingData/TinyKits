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
    public class FormStoreServiceTests:BaseTest
    {
        private FormStoreService _formStoreService;

        public FormStoreServiceTests()
        {
            _formStoreService = AutofacExt.GetFromFac<FormStoreService>();
        }

        
    }
}