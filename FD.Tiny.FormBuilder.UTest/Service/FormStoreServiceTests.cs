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
    public class FormStoreServiceTests:BaseTest
    {
        private FormStoreService _formStoreService;

        public FormStoreServiceTests()
        {
            _formStoreService = AutofacExt.GetFromFac<FormStoreService>();
        }

        [TestMethod]
        public void AddFormStoreTest()
        {
            var formStore = new FormStore()
            {
                customer_id = 1,
                form_id = 1,
            };
            
            formStore.form_data_list = new List<FormData>() {
                new FormData()
                {
                     variable_id = 21,
                      variable_value = "123"
                },
                new FormData()
                {
                    variable_id = 22,
                     variable_value = "456"
                }
            };
            formStore.label_data_list = new List<LabelData>()
            {
                new LabelData()
                {
                     lable_id = 32,
                      label_value = "123",
                },
                new LabelData()
                {
                    lable_id = 33,
                     label_value = "456"
                }
            };

            _formStoreService.AddFormStore(formStore, 0);
        }
    }
}