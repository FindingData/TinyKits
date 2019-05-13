using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Tiny.FormBuilder.UTest.Init
{
    public class Form_Init
    {
        protected FormService _formService { get; set; }

        protected LabelService _labelService { get; set; }

        public Form_Init()
        {
            this._formService = AutofacExt.GetFromFac<FormService>();
            this._labelService = AutofacExt.GetFromFac<LabelService>();
        }

        public void Inits()
        {
            Inquiry_Residential_Init();
            Business_Init();
        }

        private int AddForm(string formName)
        {
            var form = _formService.GetForm(formName);
            if (form == null)
                return _formService.AddForm(new Form() { form_name = formName }, 0);
            else
            {
                return form.form_id;
            }
        }

        private int AddLabel(int formId, Label label)
        {
            if (_labelService.IsExistlabel(formId, label.label_name_chs))
            {
                var dbLabel = _labelService.GetLabel(label.label_name_chs);
                label.label_id = dbLabel.label_id;
                _labelService.SaveLabel(label, 0);

                return label.label_id;
            }
            return _labelService.AddLabel(label, 0);
        }

        protected void Inquiry_Residential_Init()
        {
            var formId = AddForm("测试表单_住宅表单");

            var lb1 = new VariableLabel()
            {
                form_id = formId,
                label_name_chs = "物业类型",
                data_type = DataType.String,
                default_value = "40002001",
                label_config = new LabelConfig()
                {
                    database_config = new DatabaseConfig()
                    {
                        column_name = "OBJECT_TYPE",
                        table_name = "T_PROPERTY"
                    }
                }

            };
            AddLabel(formId, lb1);

            var lb2 = new VariableLabel()
            {
                form_id = formId,
                label_name_chs = "客户ID",
                data_type = DataType.Number,
                default_value = "",
                label_config = new LabelConfig()
                {
                    is_parameter = true,
                }

            };
            AddLabel(formId, lb2);

            var lb3 = new VariableLabel()
            {
                form_id = formId,
                label_name_chs = "区域代码",
                data_type = DataType.Number,
                default_value = "",
                label_config = new LabelConfig()
                {
                    is_parameter = true,
                }
            };
            AddLabel(formId, lb3);


            var lb4 = new ControlLabel()
            {
                data_type = DataType.String,
                form_id = formId,
                label_name_chs = "楼盘名称",
                label_config = new LabelConfig()
                {
                    control_config = new ControlConfig()
                    {
                        base_control = new Autocomplete(),
                    },
                    data_source = new ApiDataSource()
                    {
                        api_id = 21,
                        api_name = "获取楼盘",
                        request_parameter_map = new Dictionary<string, string>()
                           {
                               { "customer_id","客户ID" },
                               { "pca_code","区域代码" },
                               { "new_purpose_id","物业类型" }
                           },
                        response_parameter_map = new Dictionary<string, string>()
                           {
                               { "construction_name","楼盘名称" },
                               { "ADDRESS","楼盘地址" },
                               { "construction_code","楼盘编码" },
                                { "pca_code","楼盘区域" },
                           }
                    },
                    relate_list = new List<Relate>()
                    {

                    }
                }
            };
            AddLabel(formId, lb4);


            var lb5 = new ControlLabel()
            {
                data_type = DataType.String,
                form_id = formId,
                label_name_chs = "楼盘地址",
                label_config = new LabelConfig()
                {
                    control_config = new ControlConfig()
                    {
                        base_control = new Autocomplete(),
                    },
                    data_source = new ApiDataSource()
                    {
                        api_id = 21,
                        api_name = "获取楼盘",
                        request_parameter_map = new Dictionary<string, string>()
                           {
                               { "customer_id","客户ID" },
                               { "pca_code","区域代码" },
                               { "new_purpose_id","物业类型" }
                           },
                        response_parameter_map = new Dictionary<string, string>()
                           {
                               { "construction_name","楼盘名称" },
                               { "ADDRESS","楼盘地址" },
                               { "construction_code","楼盘编码" },
                                { "pca_code","楼盘区域" },
                           }
                    }
                }
            };
            AddLabel(formId, lb5);

            var lb7 = new VariableLabel()
            {
                form_id = formId,
                label_name_chs = "楼盘编码",
                data_type = DataType.String,
                default_value = "",
                label_config = new LabelConfig()
                {
                    is_parameter = false,
                },
            };
            AddLabel(formId, lb7);

            var lb8 = new ControlLabel()
            {
                data_type = DataType.String,
                form_id = formId,
                label_name_chs = "行政区",
                label_config = new LabelConfig()
                {
                    control_config = new ControlConfig()
                    {
                        base_control = new Select(),
                    },
                    data_source = new ApiDataSource()
                    {
                        api_id = 41,
                        api_name = "获取区域",
                        request_parameter_map = new Dictionary<string, string>()
                           {
                               { "pca_code","区域代码" },
                           },
                    },

                }
            };
            AddLabel(formId, lb8);

            var lb9 = new ControlLabel()
            {
                data_type = DataType.String,
                form_id = formId,
                label_name_chs = "楼栋名称",
                label_config = new LabelConfig()
                {
                    control_config = new ControlConfig()
                    {
                        base_control = new Autocomplete(),
                    },
                    data_source = new ApiDataSource()
                    {
                        api_id = 61,
                        api_name = "获取楼栋",
                        request_parameter_map = new Dictionary<string, string>()
                           {
                               { "customer_id","客户ID" },
                               { "pca_code","区域代码" },
                               { "construction_code","楼盘编码" },
                               { "new_purpose_id","物业类型" }
                           },
                        response_parameter_map = new Dictionary<string, string>()
                           {
                               { "BUILDING_NAME","楼栋名称" },
                               { "BUILDING_CODE","楼栋编码" },
                               { "OVER_FLOOR_NUM","地上总层数" },
                               { "BUILD_DATE","建筑年代" },
                           }
                    }
                }
            };
            AddLabel(formId, lb9);


            var lb10 = new VariableLabel()
            {
                form_id = formId,
                label_name_chs = "楼栋编码",
                data_type = DataType.String,
                label_config = new LabelConfig()
                {

                }
            };
            AddLabel(formId, lb10);



            var lb11 = new ControlLabel()
            {
                data_type = DataType.String,
                form_id = formId,
                label_name_chs = "房号名称",
                label_config = new LabelConfig()
                {
                    control_config = new ControlConfig()
                    {
                        base_control = new Autocomplete(),
                    },
                    data_source = new ApiDataSource()
                    {
                        api_id = 121,
                        api_name = "获取房号",
                        request_parameter_map = new Dictionary<string, string>()
                           {
                               { "customer_id","客户ID" },
                               { "pca_code","区域代码" },
                               { "construction_code","楼盘编码" },
                               { "building_code","楼栋编码" },
                               { "new_purpose_id","物业类型" }
                           },
                        response_parameter_map = new Dictionary<string, string>()
                           {
                               { "HOUSE_NAME","房号名称" },
                               { "HOUSE_CODE","房号编码" },
                               { "BUILD_AREA","建筑面积" },
                               { "FLOOR_NUM","所在楼层" },
                               { "FRONT_ID","朝向" },
                           }
                    }
                }
            };
            AddLabel(formId, lb11);


            var lb12 = new VariableLabel()
            {
                form_id = formId,
                label_name_chs = "房号编码",
                data_type = DataType.String,
                label_config = new LabelConfig()
                {

                }
            };
            AddLabel(formId, lb12);


            var lb13 = new ControlLabel()
            {
                form_id = formId,
                label_name_chs = "所在楼层",
                data_type = DataType.String,
                label_config = new LabelConfig()
                {
                    control_config = new ControlConfig()
                    {
                        base_control = new Input(),
                    }
                }
            };
            AddLabel(formId, lb13);

            var lb14 = new ControlLabel()
            {
                form_id = formId,
                label_name_chs = "朝向",
                data_type = DataType.String,
                label_config = new LabelConfig()
                {
                    data_source = new DictSource()
                    {
                        dic_type_id = 30003,
                        dic_par_ids = "30003001,30003002,30003007,30003009",
                    },
                    control_config = new ControlConfig()
                    {
                        base_control = new Select(),
                    }
                }
            };
            AddLabel(formId, lb14);

            var lb15 = new VariableLabel()
            {
                data_type = DataType.String,
                form_id = formId,
                label_name_chs = "标的名称",
                inner_value = "'@楼盘名称' + '@楼栋名称' + '@房号名称'",
                label_config = new LabelConfig()
                {
                    value_method = ValueMethod.Formula,
                    database_config = new DatabaseConfig()
                    {
                        column_name = "OBJECT_NAME",
                        table_name = "T_PROPERTY"
                    }
                },
            };
            AddLabel(formId, lb15);

            var lb16 = new ConditionLabel()
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

                        },
                    database_config = new DatabaseConfig()
                    {
                        column_name = "OBJECT_CODE",
                        table_name = "T_PROPERTY"
                    }
                },
            };
            AddLabel(formId, lb16);
        }

        protected void Business_Init()
        {
            var formId = AddForm("测试表单_业务表单");

            //placeholder,clearable,readonly,filterable
            var lb1 = new ControlLabel()
            {
                form_id = formId,
                label_name_chs = "贷款类型",
                data_type = DataType.Number,
                label_type = LabelType.control,
                label_config = new LabelConfig()
                {
                    control_config = new ControlConfig()
                    {
                        base_control = new Select(),
                        control_sort = 1,
                    },
                    data_source = new DictSource()
                    {
                        dic_type_id = 40047,
                        dic_par_ids = "40047001,40047002,40047003,40047004",
                    },
                    database_config = new DatabaseConfig()
                    {
                        column_name = "LOAN_TYPE",
                        table_name = "T_PROJECT"
                    }
                }
            };
            AddLabel(formId,lb1);
            var lb2 = new ControlLabel()
            {
                form_id = formId,
                label_name_chs = "详细预估",
                data_type = DataType.Number,
                label_config = new LabelConfig()
                {
                    control_config = new ControlConfig()
                    {
                        base_control = new Select(),
                        control_sort = 2,
                    },
                    database_config = new DatabaseConfig()
                    {
                        column_name = "LOAN_AMOUNT",
                        table_name = "T_PROJECT"
                    },
                    data_source = new CustomDataSource()
                    {
                        value = "1,0",
                        separtor = ","
                    },
                }
            };
            AddLabel(formId, lb2);

            var lb3 = new ControlLabel()
            {
                form_id = formId,
                data_type = DataType.Number,
                label_name_chs = "客户经理",
                label_config = new LabelConfig()
                {
                    control_config = new ControlConfig()
                    {
                        base_control = new Select(),
                        control_sort = 3,
                    },
                    data_source = new ApiDataSource()
                    {
                        api_id = 81,
                        api_name = "获取用户列表",
                        request_parameter_map = new Dictionary<string, string>() { { "customer_id", "客户ID" } },
                        response_parameter_map = new Dictionary<string, string>() { { "user_id", "客户经理" } }
                    },
                    database_config = new DatabaseConfig()
                    {
                        column_name = "BCM_USER_ID",
                        table_name = "T_PROJECT"
                    }
                }
            };
            AddLabel(formId, lb3);

            var lb4 = new ControlLabel()
            {
                form_id = formId,
                data_type = DataType.String,
                label_name_chs = "借款人",
                label_config = new LabelConfig()
                {
                    control_config = new ControlConfig()
                    {
                        base_control = new Input(),
                        control_sort = 4,
                    }
                }
            };
            AddLabel(formId, lb4);

            var lb5 = new ControlLabel()
            {
                form_id = formId,
                data_type = DataType.String,
                label_name_chs = "借款人电话",
                label_config = new LabelConfig()
                {
                    control_config = new ControlConfig()
                    {
                        base_control = new Input(),
                        control_sort = 5,
                    }
                }
            };
            AddLabel(formId, lb5);

            var lb6 = new VariableLabel()
            {
                form_id = formId,
                data_type = DataType.Number,
                label_name_chs = "客户ID",
                default_value = 3,
                inner_value = "3",
                label_config = new LabelConfig()
                {
                    database_config = new DatabaseConfig(),
                }
            };
            AddLabel(formId, lb6);           
        }

       
    }
}
