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
    public class FormServiceTests:BaseTest
    {
        private FormService _formService;
        private FormVariableService _formVariableService;

        public FormServiceTests()
        {
            _formService = AutofacExt.GetFromFac<FormService>();
            _formVariableService = AutofacExt.GetFromFac<FormVariableService>();
        }

        [TestMethod()]
        public void FormServiceTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RetriveDbDataTest()
        {
            var dbDataList = _formService.RetriveDbData(21);
            foreach (var dbData in dbDataList)
            {
                Console.WriteLine($"t:{dbData.table_name}---c:{dbData.column_name}----v:{dbData.column_value}");
            }

        }

        [TestMethod()]
        public void AddFormTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SaveFormTest()
        {
            var form = _formService.GetForm(1);
            form.variable_list = _formVariableService.GetFormVariableList(1);
            form.group_list = new List<FormGroup>();
            _formService.SaveForm(form, 0);            
        }

        [TestMethod]
        public void SubmitConditionVariableTest()
        {
            var store = new FormStore();
            store.form_id = 1;
            store.customer_id = 3;
            store.label_data_list = new List<LabelData> {
                new LabelData(){ lable_id = 41, label_name_chs = "楼盘名称", label_value = "1"},
                new LabelData(){ lable_id = 42, label_name_chs = "楼栋名称", label_value = "1"},
                new LabelData(){ lable_id = 43, label_name_chs = "房号名称", label_value = "1901号"}
            };
            _formService.Submit(store);            
        }

        [TestMethod()]
        public void DelFormTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetFormTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void QueryFormTest()
        {
            Assert.Fail();
        }
    }
}