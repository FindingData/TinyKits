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
    public class FormServiceTests : BaseTest
    {
        private FormService _formService;
        //private FormVariableService _formVariableService;

        public FormServiceTests()
        {
            _formService = AutofacExt.GetFromFac<FormService>();
            //  _formVariableService = AutofacExt.GetFromFac<FormVariableService>();
        }


        [TestMethod()]
        public void RetriveDbDataTest()
        {
            var dbDataList = _formService.RetriveDbData(125);
            foreach (var dbData in dbDataList)
            {
                Console.WriteLine($"t:{dbData.table_name}---c:{dbData.column_name}----v:{dbData.column_value}");
            }

        }

        [TestMethod()]
        public void AddFormTest()
        {
            var form = new Form()
            {
                form_desc = "一个测试表单",
                form_name = "测试表单",
                group_list = new List<FormGroup>()
                {
                    new FormGroup(){ group_name = "区位"},
                }
            };
            var formId = _formService.AddForm(form, 0);
            Assert.IsTrue(formId > 0);
        }

        [TestMethod()]
        public void SaveFormTest()
        {
            var form = _formService.GetForm(81);

            //   form.variable_list = _formVariableService.GetFormVariableList(1);
            form.group_list = new List<FormGroup>()
                {
                    new FormGroup(){ group_name = "区位"},
                };
            _formService.SaveForm(form, 0);
        }

        [TestMethod]
        public void SubmitConditionVariableTest()
        {
            var store = new FormStore();
            store.form_id = 81;
            store.customer_id = 3;
            store.label_data_list = new List<LabelData> {
                new LabelData(){ label_id = 41, label_name_chs = "楼盘名称", label_value = "1"},
                new LabelData(){ label_id = 42, label_name_chs = "楼栋名称", label_value = "1"},
                new LabelData(){ label_id = 43, label_name_chs = "房号名称", label_value = "1901号"},
                new LabelData(){ label_id = 44, label_name_chs = "楼盘编码", label_value = "123"},
                new LabelData(){ label_id = 84, label_name_chs = "楼栋编码", label_value = "123456"},
                new LabelData(){ label_id = 85, label_name_chs = "房号编码", label_value = "12345678"}
            };

            _formService.Submit(store, 0);
        }

        [TestMethod()]
        public void DelFormTest()
        {
            _formService.DelForm(21, 0);
        }

        [TestMethod()]
        public void GetFormTest()
        {
            var form = _formService.GetForm(81);
            Assert.IsNotNull(form);
        }

        [TestMethod()]
        public void QueryFormTest()
        {
            var fromList = _formService.QueryForm("");
            Assert.IsNotNull(fromList);
        }

        [TestMethod()]
        public void BuildFormTest()
        {
            var dic = new Dictionary<string, string>();
            dic.Add("公司ID", "3");
            var form = _formService.BuildForm(81, dic);
            Assert.IsNotNull(form.group_list);

        }

        
    }
}