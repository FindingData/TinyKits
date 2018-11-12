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
    public class FormVariableServiceTests : BaseTest
    {
        private FormVariableService _formVariableService;


        public FormVariableServiceTests()
        {
            _formVariableService = AutofacExt.GetFromFac<FormVariableService>();
        }

        [TestMethod]
        public void AddFormVariabelTest()
        {
            var variable = new FormVariable();

            variable.database_config = new DatabaseConfig()
            {
                column_name = "column_value",
                table_name = "t_col",
            };
            variable.form_id = 1;            
            variable.variable_name_chs = "我";
            variable.data_type = DataType.String;
            variable.default_value = "column_value";
            _formVariableService.AddFormVariabel(variable, 0);
        }

        [TestMethod]
        public void AddLabelVariableTest()
        {
            var var1 = new LabelVariable()
            {
                form_id = 1,
                variable_name_chs = "标的名称",
                data_type = DataType.String,
                default_value = "标的名称",
                value_method = ValueMethod.Formula,
                inner_value = "'@楼盘名称' + '@楼栋名称' + '@房号名称'"
            };

            _formVariableService.AddFormVariabel(var1, 0);
        }

        [TestMethod]
        public void UpdateVariableTest()
        {
            var var1 = _formVariableService.GetFormVariable(23) as LabelVariable;
            var1.inner_value = "'@楼盘名称' + '@楼栋名称' + '@房号名称'";
            _formVariableService.SaveFormVariable(var1, 0);
        }

        [TestMethod]
        public void AddConditionVariableTest()
        {
            var var1 = new ConditionVariable()
            {
                form_id = 1,
                variable_name_chs = "标的编码",
                data_type = DataType.String,
                default_value = "标的编码",
                condition_list = new List<Condition>()
                {
                      new Condition{ condition_expr = "@楼盘编码 != ''", condition_item = new ConditionItem()
                        {
                             inner_value = "@楼盘编码 ",
                              value_method = ValueMethod.Formula,
                        }
                      },
                       new Condition(){ condition_expr = "@楼栋编码 != ''", condition_item = new ConditionItem()
                        {
                             inner_value = "@楼栋编码 ",
                              value_method = ValueMethod.Formula,
                        } },
                        new Condition(){ condition_expr = "@房号编码 != ''", condition_item = new ConditionItem()
                        {
                             inner_value = "@房号编码 ",
                              value_method = ValueMethod.Formula,
                        } }
                }
            };

            _formVariableService.AddFormVariabel(var1, 0);
        }


        [TestMethod]
        public void UpdateConditionVariableTest()
        {
            var var1 = _formVariableService.GetFormVariable(24) as ConditionVariable;
            var1.condition_list = new List<Condition>()
                {
                  new Condition(){ condition_expr = "'@房号编码' != ''", condition_item = new ConditionItem()
                        {
                             inner_value = "@房号编码 ",
                              value_method = ValueMethod.Formula,
                        } },
                    new Condition(){ condition_expr = "'@楼栋编码' != ''", condition_item = new ConditionItem()
                        {
                             inner_value = "@楼栋编码 ",
                              value_method = ValueMethod.Formula,
                        } },
                      new Condition{ condition_expr = "'@楼盘编码' != ''", condition_item = new ConditionItem()
                        {
                             inner_value = "@楼盘编码 ",
                              value_method = ValueMethod.Formula,
                        }
                      },
                };
            _formVariableService.SaveFormVariable(var1, 0);
        }
       
        [TestMethod]
        public void GetConditionLabelTest()
        {
            var var1 = _formVariableService.GetFormVariable(23);
            LabelVariable var2 = var1 as LabelVariable;
            Assert.IsInstanceOfType(var1,typeof(LabelVariable));
        }
    }
}