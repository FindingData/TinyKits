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
    public class LabelServiceTests : BaseTest
    {

        private LabelService _labelService;


        public LabelServiceTests()
        {
            _labelService = AutofacExt.GetFromFac<LabelService>();
        }

        [TestMethod()]
        public void LabelPropertyTest()
        {
            var lb = new ControlLabel()
            {
                form_id = 1,
                label_name_chs = "文本测试",
                data_type = DataType.String,
               
                label_config = new ControlConfig() {
                    control_type = "input",
                    label_sort = 1,
                    group_name = "基础"
                },              
            };
            _labelService.AddLabel(lb, 0);
        }



        [TestMethod()]
        public void AddLabelTest()
        {
            var formId = 81;

            var lb1 = new VariableLabel()
            {
                form_id = formId,
                label_name_chs = "楼盘编码",
                data_type = DataType.String,
                label_config = new VariableConfig() {
                      
                }
            };
            _labelService.AddLabel(lb1, 0);

            var lb2 = new VariableLabel()
            {
                form_id = formId,
                label_name_chs = "楼栋编码",
                data_type = DataType.String,
                label_config = new VariableConfig() {
                  
                }
            };
            _labelService.AddLabel(lb2, 0);

            var lb3 = new VariableLabel()
            {
                form_id = formId,
                label_name_chs = "房号编码",
                data_type = DataType.String,
                label_config = new VariableConfig() {
                    
                }
            };
            _labelService.AddLabel(lb3, 0);


            var lb4 = new ControlLabel()
            {
                data_type = DataType.String,
                form_id = formId,
                label_name_chs = "楼盘名称",
                label_config = new ControlConfig()
                {
                    group_name = "区位",
                }
            };
            _labelService.AddLabel(lb4, 0);

            var lb5 = new ControlLabel()
            {
                data_type = DataType.String,
                form_id = formId,
                label_name_chs = "楼栋名称",
                label_config = new ControlConfig()
                {
                    group_name = "区位",
                }
            };
            _labelService.AddLabel(lb5, 0);

            var lb6 = new ControlLabel()
            {
                data_type = DataType.String,
                form_id = formId,
                label_name_chs = "房号名称",
                label_config = new ControlConfig()
                {
                    group_name = "区位",
                }
            };
            _labelService.AddLabel(lb6, 0);

            var lb7 = new VariableLabel()
            {
                data_type = DataType.String,
                form_id = formId,
                label_name_chs = "标的名称",
                inner_value = "'@楼盘名称' + '@楼栋名称' + '@房号名称'",
                label_config = new VariableConfig()
               {
                   value_method = ValueMethod.Formula,                   
               },
               
            };
            _labelService.AddLabel(lb7, 0);


            var lb8 = new ConditionLabel()
            {
                data_type = DataType.String,
                form_id = formId,
                label_name_chs = "标的编码",
              
                label_config = new ConditionConfig()
                {
                    condition_list = new List<Condition>()
                    {
                           new Condition(){ condition_expr = "@房号编码 != ''", condition_item = new ConditionItem()
                            {
                                 inner_value = "@房号编码 ",
                                  value_method = ValueMethod.Formula,
                            } },
                                 new Condition(){ condition_expr = "@楼栋编码 != ''", condition_item = new ConditionItem()
                            {
                                 inner_value = "@楼栋编码 ",
                                  value_method = ValueMethod.Formula,
                            } },
                          new Condition{ condition_expr = "@楼盘编码 != ''", condition_item = new ConditionItem()
                            {
                                 inner_value = "@楼盘编码 ",
                                  value_method = ValueMethod.Formula,
                            }
                          },
                     
                        }
                },
            };
            _labelService.AddLabel(lb8, 0);

            var lb9 = new VariableLabel()
            {
                data_type = DataType.String,
                form_id = formId,
                label_name_chs = "公司ID",
                label_config = new VariableConfig()
                {
                    is_parameter = true,
                },
            };
            _labelService.AddLabel(lb9, 0);

        }       
    }
}