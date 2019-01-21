using Microsoft.VisualStudio.TestTools.UnitTesting;
using FD.Tiny.FormBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FD.Tiny.FormBuilder.UTest;
using FD.Tiny.FormBuilder.Demo;
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

        [TestMethod]
        public void GetLabelList()
        {
            var ls = _labelService.GetLabelList(81);
            foreach (var l in ls)
            {
                Assert.IsNotNull(l);
            }
        }


        [TestMethod()]
        public void LabelPropertyTest()
        {
            var lb = new ControlLabel()
            {
                form_id = 8,
                label_name_chs = "文本测试",
                data_type = DataType.String,
                form = null,
                inner_value = "",
                label_type = LabelType.condition,
                label_config = new LabelConfig()
                {
                    control_config = new ControlConfig()
                    {
                        control_type = "input",
                        control_sort = 1,
                        group_name = "基础",
                        control_options = new List<Option>()
                       {
                            new Option(){ key = "placeholder",value= "你好"},
                            new Option(){ key="readonly", value = false},
                       }
                    },                                                       
                    database_config = null,                                       
                },
            };
            Console.WriteLine(JsonHelper.Instance.Serialize(lb));
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
                label_config = new LabelConfig() {
                      
                }
            };
            _labelService.AddLabel(lb1, 0);

            var lb2 = new VariableLabel()
            {
                form_id = formId,
                label_name_chs = "楼栋编码",
                data_type = DataType.String,
                label_config = new LabelConfig() {
                  
                }
            };
            _labelService.AddLabel(lb2, 0);

            var lb3 = new VariableLabel()
            {
                form_id = formId,
                label_name_chs = "房号编码",
                data_type = DataType.String,
                label_config = new LabelConfig() {
                    
                }
            };
            _labelService.AddLabel(lb3, 0);


            var lb4 = new ControlLabel()
            {
                data_type = DataType.String,
                form_id = formId,
                label_name_chs = "楼盘名称",
                label_config = new LabelConfig()
                {
                    control_config = new ControlConfig()
                    {
                        group_name = "区位",
                        control_type = "autocomplete",
                    },
                    data_source = new ApiDataSource()
                    {
                        //api_id = 21,
                        request_parameter_map = new Dictionary<string, string>()
                           {
                               { "customer_id","客户ID" },
                               { "pca_code","区域代码" },
                               { "new_purpose_id","楼盘用途" }
                           },
                        response_parameter_map = new Dictionary<string, string>()
                           {
                               { "construction_name","楼盘名称" },
                               { "construction_code","楼盘编码" },
                           }
                    },

                    relate_list = new List<Relate>()
                     {
                          new Relate(){ relate_label_name = "楼栋名称"},
                          new Relate(){ relate_label_name = "房号名称"}
                     }
                }
            };
            _labelService.AddLabel(lb4, 0);

            var lb5 = new ControlLabel()
            {
                data_type = DataType.String,
                form_id = formId,
                label_name_chs = "楼栋名称",
                label_config = new LabelConfig()
                {
                    control_config = new ControlConfig()
                    {
                        group_name = "区位",
                        control_type = "autocomplete",
                    },
                    data_source = new ApiDataSource()
                    {
                        //api_id = 61,
                        request_parameter_map = new Dictionary<string, string>()
                           {
                               { "construction_code","楼盘编码" },
                               { "customer_id","客户ID" },
                               { "pca_code","区域代码" },
                               { "new_purpose_id","楼盘用途" }
                           },
                        response_parameter_map = new Dictionary<string, string>()
                           {
                               { "building_name","楼栋名称" },
                               { "building_code","楼栋编码" },
                           }
                    },

                    relate_list = new List<Relate>()
                        {
                        new Relate(){ relate_label_name="房号名称"}
                        }
                }
            };
            _labelService.AddLabel(lb5, 0);

            var lb6 = new ControlLabel()
            {
                data_type = DataType.String,
                form_id = formId,
                label_name_chs = "房号名称",
                label_config = new LabelConfig()
                {
                   control_config = new ControlConfig() {
                       group_name = "区位",
                   }
                }
            };
            _labelService.AddLabel(lb6, 0);

            var lb7 = new VariableLabel()
            {
                data_type = DataType.String,
                form_id = formId,
                label_name_chs = "标的名称",
                inner_value = "'@楼盘名称' + '@楼栋名称' + '@房号名称'",
                label_config = new LabelConfig()
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
              
                label_config = new LabelConfig()
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
                label_name_chs = "客户ID",
                label_config = new LabelConfig()
                {
                    is_parameter = true,
                },
            };

            _labelService.AddLabel(lb9, 0);

            var lb10 = new VariableLabel()
            {
                data_type = DataType.String,
                form_id = formId,
                label_name_chs = "区域代码",
                label_config = new LabelConfig()
                {
                    is_parameter = true,
                },
            };

            _labelService.AddLabel(lb10, 0);


            var lb11 = new VariableLabel()
            {
                data_type = DataType.String,
                form_id = formId,
                label_name_chs = "楼盘用途",
                label_config = new LabelConfig()
                {
                    is_parameter = true,
                },
            };

            _labelService.AddLabel(lb11, 0);
        }       
        
    }
}