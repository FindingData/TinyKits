using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FD.Tiny.FormBuilder.Demo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FD.Tiny.FormBuilder.UTest
{
    [TestClass]
    public class Label_Base_Test:BaseTest
    {
        protected string FormName { get; set; }
        protected int FormId { get; set; }
        protected int StoreId { get; set; }
        protected int CustomerId { get; set; }

        protected IList<Label> LabelList { get; set; }
        protected FormService _formService { get; set; }
        protected LabelService _labelService { get; set; }
        protected FormStoreService _formStoreService { get; set; }


        #region 附加测试特性
        public Label_Base_Test(string formName)
        {
           
            _formService = AutofacExt.GetFromFac<FormService>();
            _labelService = AutofacExt.GetFromFac<LabelService>();
            _formStoreService = AutofacExt.GetFromFac<FormStoreService>();


            this.FormName = formName;
            var form = _formService.GetForm(FormName);          
            if (form == null)
                FormId = _formService.AddForm(new Form() { form_name = FormName }, 0);
            else
            {
                FormId = form.form_id;
            }
            
        }
        //
        // 编写测试时，可以使用以下附加特性: 
        //
        // 在运行类中的第一个测试之前使用 ClassInitialize 运行代码
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // 在类中的所有测试都已运行之后使用 ClassCleanup 运行代码
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        //在运行每个测试之前，使用 TestInitialize 来运行代码
        //[TestInitialize()]
        //public void LabelInitialize()
        //{
              
        //}

      
        public int AddLabel(Label label)
        {
            if (_labelService.IsExistlabel(FormId, label.label_name_chs))
            {
                var dbLabel = _labelService.GetLabel(label.label_name_chs);
                 label.label_id = dbLabel.label_id;                
                _labelService.SaveLabel(label, 0);

                return label.label_id;
            }
            return _labelService.AddLabel(label, 0);
        }

        public LabelData AddLabelData(string labelName, string value)
        {
            var ldata = new LabelData();
            var label = LabelList.FirstOrDefault(l => l.label_name_chs == labelName);
            if (label == null)
                throw new ArgumentException("label not exist.");
            ldata.label_id = label.label_id;
            ldata.label_name_chs = labelName;
            ldata.label_value = value;
            return ldata;
        }

        public void SubmitForms(List<LabelData> dataList)
        {
            var store = new FormStore();
            store.form_id = FormId;
            store.customer_id = CustomerId;
            store.label_data_list = dataList;
            StoreId = _formService.Submit(store, 0);
        }
      
        //
        // 在每个测试运行完之后，使用 TestCleanup 来运行代码
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
           
        //}
        //
        #endregion

        #region form label init
        protected void Inquiry_Residential_Init()
        {
            var lb1 = new VariableLabel()
            {
                form_id = FormId,
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
            AddLabel(lb1);

            var lb2 = new VariableLabel()
            {
                form_id = FormId,
                label_name_chs = "客户ID",
                data_type = DataType.Number,
                default_value = "",
                label_config = new LabelConfig()
                {
                     is_parameter = true,
                }

            };
            AddLabel(lb2);

            var lb3 = new VariableLabel()
            {
                form_id = FormId,
                label_name_chs = "区域代码",
                data_type = DataType.Number,
                default_value = "",
                label_config = new LabelConfig()
                {
                    is_parameter = true, 
                }
            };
            AddLabel(lb3);


            var lb4 = new ControlLabel()
            {
                data_type = DataType.String,
                form_id = FormId,
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
            AddLabel(lb4);


            var lb5 = new ControlLabel()
            {
                data_type = DataType.String,
                form_id = FormId,
                label_name_chs = "楼盘地址",
                label_config = new LabelConfig()
                {
                    control_config = new ControlConfig()
                    {
                        base_control = new  Autocomplete(),
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
            AddLabel(lb5);

            var lb7 = new VariableLabel()
            {
                form_id = FormId,
                label_name_chs = "楼盘编码",
                data_type = DataType.String,
                default_value = "",
                label_config = new LabelConfig()
                {
                    is_parameter = false,
                },
            };
            AddLabel(lb7);

            var lb8 = new ControlLabel()
            {
                data_type = DataType.String,
                form_id = FormId,
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
            AddLabel(lb8);

            var lb9 = new ControlLabel()
            {
                data_type = DataType.String,
                form_id = FormId,
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
            AddLabel(lb9);


            var lb10 = new VariableLabel()
            {
                form_id = FormId,
                label_name_chs = "楼栋编码",
                data_type = DataType.String,
                label_config = new LabelConfig()
                {

                }
            };
            AddLabel(lb10);



            var lb11 = new ControlLabel()
            {
                data_type = DataType.String,
                form_id = FormId,
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
            AddLabel(lb11);


            var lb12 = new VariableLabel()
            {
                form_id = FormId,
                label_name_chs = "房号编码",
                data_type = DataType.String,
                label_config = new LabelConfig()
                {

                }
            };
            AddLabel(lb12);


            var lb13 = new ControlLabel()
            {
                form_id = FormId,
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
            AddLabel(lb13);

            var lb14 = new ControlLabel()
            {
                form_id = FormId,
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
            AddLabel(lb14);

            var lb15 = new VariableLabel()
            {
                data_type = DataType.String,
                form_id = FormId,
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
            AddLabel(lb15);

            var lb16 = new ConditionLabel()
            {
                data_type = DataType.String,
                form_id = FormId,
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
            AddLabel(lb16);

            LoadFormLables();

            //var lb16 = new ControlLabel()
            //{
            //    form_id = FormId,
            //    label_name_chs = "地面装修",
            //    data_type = DataType.String,
            //    label_config = new LabelConfig()
            //    {
            //        data_source = new DictSource()
            //        {
            //            dic_type_id = 30085,
            //        },
            //        control_config = new ControlConfig()
            //        {
            //            control_type = "select",
            //        },
            //        relate_list = new List<Relate>()
            //        {
            //             new ConditionRelate(){ direction_type = DirectionType.reverse,
            //              relate_label_name = "物业子类型",
            //              relate_type = RelateType.visibility,
            //               condition_expr = "@物业子类型 == 40002001004",
            //             },
            //        }
            //    }
            //};
            //AddLabel(lb16);

            //var lb17 = new ControlLabel()
            //{
            //    form_id = FormId,
            //    label_name_chs = "顶棚装修",
            //    data_type = DataType.String,
            //    label_config = new LabelConfig()
            //    {
            //        data_source = new DictSource()
            //        {
            //            dic_type_id = 30087,
            //        },
            //        control_config = new ControlConfig()
            //        {
            //            control_type = "select",
            //        },
            //        relate_list = new List<Relate>()
            //        {
            //             new ConditionRelate(){ direction_type = DirectionType.reverse,
            //              relate_label_name = "物业子类型",
            //              relate_type = RelateType.visibility,
            //               condition_expr = "@物业子类型 == 40002001004 || @物业子类型 == 40002001005",
            //             },
            //        }
            //    }
            //};
            //AddLabel(lb17);


        }

        //protected void Inquiry_Business_Init()
        //{
        //    var lb1 = new VariableLabel()
        //    {
        //        form_id = FormId,
        //        label_name_chs = "物业类型",
        //        data_type = DataType.String,
        //        default_value = "40002002",
        //        label_config = new LabelConfig()
        //        {
        //            database_config = new DatabaseConfig()
        //            {
        //                column_name = "OBJECT_TYPE",
        //                table_name = "T_PROPERTY"
        //            }
        //        }

        //    };
        //    AddLabel(lb1);

        //    var lb2 = new VariableLabel()
        //    {
        //        form_id = FormId,
        //        label_name_chs = "客户ID",
        //        data_type = DataType.Number,
        //        default_value = "",
        //        label_config = new LabelConfig()
        //        {
        //            is_parameter = true,
        //        }

        //    };
        //    AddLabel(lb2);

        //    var lb3 = new VariableLabel()
        //    {
        //        form_id = FormId,
        //        label_name_chs = "区域代码",
        //        data_type = DataType.Number,
        //        default_value = "",
        //        label_config = new LabelConfig()
        //        {
        //            is_parameter = true,
        //        }
        //    };
        //    AddLabel(lb3);


        //    var lb4 = new ControlLabel()
        //    {
        //        data_type = DataType.String,
        //        form_id = FormId,
        //        label_name_chs = "项目名称",
        //        label_config = new LabelConfig()
        //        {
        //            control_config = new ControlConfig()
        //            {
        //                base_control = new Autocomplete(),
        //            },
        //            data_source = new ApiDataSource()
        //            {
        //                api_id = 21,
        //                api_name = "获取楼盘",
        //                request_parameter_map = new Dictionary<string, string>()
        //                   {
        //                       { "customer_id","客户ID" },
        //                       { "pca_code","区域代码" },
        //                       { "new_purpose_id","物业类型" }
        //                   },
        //                response_parameter_map = new Dictionary<string, string>()
        //                   {
        //                       { "construction_name","楼盘名称" },
        //                       { "ADDRESS","楼盘地址" },
        //                       { "construction_code","楼盘编码" },
        //                        { "pca_code","楼盘区域" },
        //                   }
        //            },
        //            relate_list = new List<Relate>()
        //            {

        //            }
        //        }
        //    };
        //    AddLabel(lb4);


        //    var lb5 = new ControlLabel()
        //    {
        //        data_type = DataType.String,
        //        form_id = FormId,
        //        label_name_chs = "楼盘地址",
        //        label_config = new LabelConfig()
        //        {
        //            control_config = new ControlConfig()
        //            {
        //                base_control = new Autocomplete(),
        //            },
        //            data_source = new ApiDataSource()
        //            {
        //                api_id = 21,
        //                api_name = "获取楼盘",
        //                request_parameter_map = new Dictionary<string, string>()
        //                   {
        //                       { "customer_id","客户ID" },
        //                       { "pca_code","区域代码" },
        //                       { "new_purpose_id","物业类型" }
        //                   },
        //                response_parameter_map = new Dictionary<string, string>()
        //                   {
        //                       { "construction_name","楼盘名称" },
        //                       { "ADDRESS","楼盘地址" },
        //                       { "construction_code","楼盘编码" },
        //                        { "pca_code","楼盘区域" },
        //                   }
        //            }
        //        }
        //    };
        //    AddLabel(lb5);

        //    var lb7 = new VariableLabel()
        //    {
        //        form_id = FormId,
        //        label_name_chs = "楼盘编码",
        //        data_type = DataType.String,
        //        default_value = "",
        //        label_config = new LabelConfig()
        //        {
        //            is_parameter = false,
        //        },
        //    };
        //    AddLabel(lb7);

        //    var lb8 = new ControlLabel()
        //    {
        //        data_type = DataType.String,
        //        form_id = FormId,
        //        label_name_chs = "行政区",
        //        label_config = new LabelConfig()
        //        {
        //            control_config = new ControlConfig()
        //            {
        //                base_control = new Select(),
        //            },
        //            data_source = new ApiDataSource()
        //            {
        //                api_id = 41,
        //                api_name = "获取区域",
        //                request_parameter_map = new Dictionary<string, string>()
        //                   {
        //                       { "pca_code","区域代码" },
        //                   },
        //            },

        //        }
        //    };
        //    AddLabel(lb8);

        //    var lb9 = new ControlLabel()
        //    {
        //        data_type = DataType.String,
        //        form_id = FormId,
        //        label_name_chs = "楼栋名称",
        //        label_config = new LabelConfig()
        //        {
        //            control_config = new ControlConfig()
        //            {
        //                base_control = new Autocomplete(),
        //            },
        //            data_source = new ApiDataSource()
        //            {
        //                api_id = 61,
        //                api_name = "获取楼栋",
        //                request_parameter_map = new Dictionary<string, string>()
        //                   {
        //                       { "customer_id","客户ID" },
        //                       { "pca_code","区域代码" },
        //                       { "construction_code","楼盘编码" },
        //                       { "new_purpose_id","物业类型" }
        //                   },
        //                response_parameter_map = new Dictionary<string, string>()
        //                   {
        //                       { "BUILDING_NAME","楼栋名称" },
        //                       { "BUILDING_CODE","楼栋编码" },
        //                       { "OVER_FLOOR_NUM","地上总层数" },
        //                       { "BUILD_DATE","建筑年代" },
        //                   }
        //            }
        //        }
        //    };
        //    AddLabel(lb9);


        //    var lb10 = new VariableLabel()
        //    {
        //        form_id = FormId,
        //        label_name_chs = "楼栋编码",
        //        data_type = DataType.String,
        //        label_config = new LabelConfig()
        //        {

        //        }
        //    };
        //    AddLabel(lb10);



        //    var lb11 = new ControlLabel()
        //    {
        //        data_type = DataType.String,
        //        form_id = FormId,
        //        label_name_chs = "房号名称",
        //        label_config = new LabelConfig()
        //        {
        //            control_config = new ControlConfig()
        //            {
        //                base_control = new Autocomplete(),
        //            },
        //            data_source = new ApiDataSource()
        //            {
        //                api_id = 121,
        //                api_name = "获取房号",
        //                request_parameter_map = new Dictionary<string, string>()
        //                   {
        //                       { "customer_id","客户ID" },
        //                       { "pca_code","区域代码" },
        //                       { "construction_code","楼盘编码" },
        //                       { "building_code","楼栋编码" },
        //                       { "new_purpose_id","物业类型" }
        //                   },
        //                response_parameter_map = new Dictionary<string, string>()
        //                   {
        //                       { "HOUSE_NAME","房号名称" },
        //                       { "HOUSE_CODE","房号编码" },
        //                       { "BUILD_AREA","建筑面积" },
        //                       { "FLOOR_NUM","所在楼层" },
        //                       { "FRONT_ID","朝向" },
        //                   }
        //            }
        //        }
        //    };
        //    AddLabel(lb11);


        //    var lb12 = new VariableLabel()
        //    {
        //        form_id = FormId,
        //        label_name_chs = "房号编码",
        //        data_type = DataType.String,
        //        label_config = new LabelConfig()
        //        {

        //        }
        //    };
        //    AddLabel(lb12);


        //    var lb13 = new ControlLabel()
        //    {
        //        form_id = FormId,
        //        label_name_chs = "所在楼层",
        //        data_type = DataType.String,
        //        label_config = new LabelConfig()
        //        {
        //            control_config = new ControlConfig()
        //            {
        //                base_control = new Input(),
        //            }
        //        }
        //    };
        //    AddLabel(lb13);

        //    var lb14 = new ControlLabel()
        //    {
        //        form_id = FormId,
        //        label_name_chs = "朝向",
        //        data_type = DataType.String,
        //        label_config = new LabelConfig()
        //        {
        //            data_source = new DictSource()
        //            {
        //                dic_type_id = 30003,
        //                dic_par_ids = "30003001,30003002,30003007,30003009",
        //            },
        //            control_config = new ControlConfig()
        //            {
        //                base_control = new Select(),
        //            }
        //        }
        //    };
        //    AddLabel(lb14);

        //    var lb15 = new VariableLabel()
        //    {
        //        data_type = DataType.String,
        //        form_id = FormId,
        //        label_name_chs = "标的名称",
        //        inner_value = "'@楼盘名称' + '@楼栋名称' + '@房号名称'",
        //        label_config = new LabelConfig()
        //        {
        //            value_method = ValueMethod.Formula,
        //            database_config = new DatabaseConfig()
        //            {
        //                column_name = "OBJECT_NAME",
        //                table_name = "T_PROPERTY"
        //            }
        //        },
        //    };
        //    AddLabel(lb15);

        //    var lb16 = new ConditionLabel()
        //    {
        //        data_type = DataType.String,
        //        form_id = FormId,
        //        label_name_chs = "标的编码",

        //        label_config = new LabelConfig()
        //        {
        //            condition_list = new List<Condition>()
        //            {
        //                   new Condition(){ condition_expr = "@房号编码 != ''", condition_item = new ConditionItem()
        //                    {
        //                         inner_value = "@房号编码 ",
        //                          value_method = ValueMethod.Formula,
        //                    } },
        //                         new Condition(){ condition_expr = "@楼栋编码 != ''", condition_item = new ConditionItem()
        //                    {
        //                         inner_value = "@楼栋编码 ",
        //                          value_method = ValueMethod.Formula,
        //                    } },
        //                  new Condition{ condition_expr = "@楼盘编码 != ''", condition_item = new ConditionItem()
        //                    {
        //                         inner_value = "@楼盘编码 ",
        //                          value_method = ValueMethod.Formula,
        //                    }
        //                  },

        //                },
        //            database_config = new DatabaseConfig()
        //            {
        //                column_name = "OBJECT_CODE",
        //                table_name = "T_PROPERTY"
        //            }
        //        },
        //    };
        //    AddLabel(lb16);

        //    LoadFormLables();           
        //}


        protected void InitBusinessLables()
        {
            //placeholder,clearable,readonly,filterable
            var lb1 = new ControlLabel()
            {
                form_id = FormId,
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
            AddLabel(lb1);
            var lb2 = new ControlLabel()
            {
                form_id = FormId,
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
            AddLabel(lb2);

            var lb3 = new ControlLabel()
            {
                form_id = FormId,
                data_type = DataType.Number,
                label_name_chs = "客户经理",
                label_config = new LabelConfig()
                {
                    control_config = new ControlConfig()
                    {
                        base_control = new Select(),
                        control_sort=3,                        
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
            AddLabel(lb3);

            var lb4 = new ControlLabel()
            {
                form_id = FormId,
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
            AddLabel(lb4);

            var lb5 = new ControlLabel()
            {
                form_id = FormId,
                data_type = DataType.String,
                label_name_chs = "借款人电话",
                label_config = new LabelConfig()
                {
                    control_config = new ControlConfig()
                    {
                       base_control = new Input(),
                        control_sort =5,
                    }
                }
            };
            AddLabel(lb5);

            var lb6 = new VariableLabel()
            {
                form_id = FormId,
                data_type = DataType.Number,
                label_name_chs = "客户ID",
                default_value = 3,
                inner_value = "3",
                label_config = new LabelConfig()
                {                    
                    database_config = new DatabaseConfig(),
                 }
            };
            AddLabel(lb6);
            LoadFormLables();
        }


        protected void InitLabels()
        {
            var lb1 = new VariableLabel()
            {
                form_id = FormId,
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
            AddLabel(lb1);

            var lb2 = new ControlLabel()
            {
                form_id = FormId,
                label_name_chs = "物业子类型",
                data_type = DataType.String,
                label_config = new LabelConfig()
                {
                    data_source = new ApiDataSource()
                    {
                        api_id = 101,
                        api_name = "获取字典",
                        request_parameter_map = new Dictionary<string, string>() { { "dic_type_id", "物业类型" } },
                        response_parameter_map = new Dictionary<string, string>() { { "dic_par_id", "物业子类型" } },
                    },
                    control_config = new ControlConfig()
                    {
                        
                    }
                }
            };
            AddLabel(lb2);


            var lb4 = new ControlLabel()
            {
                data_type = DataType.String,
                form_id = FormId,
                label_name_chs = "楼盘名称",
                label_config = new LabelConfig()
                {
                    control_config = new ControlConfig()
                    {
                        group_name = "区位",
                       base_control = new Autocomplete(),
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
            AddLabel(lb4);

            var lb5 = new ControlLabel()
            {
                data_type = DataType.String,
                form_id = FormId,
                label_name_chs = "楼栋名称",
                label_config = new LabelConfig()
                {
                    control_config = new ControlConfig()
                    {
                        group_name = "区位",
                        base_control = new Autocomplete(),
                    },
                    data_source = new ApiDataSource()
                    {
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
            AddLabel(lb5);

            var lb6 = new ControlLabel()
            {
                data_type = DataType.String,
                form_id = FormId,
                label_name_chs = "房号名称",
                label_config = new LabelConfig()
                {
                    control_config = new ControlConfig()
                    {
                        group_name = "区位",
                        base_control = new Input(),
                    },

                }
            };
            AddLabel(lb6);

            var lb7 = new VariableLabel()
            {
                data_type = DataType.String,
                form_id = FormId,
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
            AddLabel(lb7);

            var lb8 = new ConditionLabel()
            {
                data_type = DataType.String,
                form_id = FormId,
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
            AddLabel(lb8);

            var lb9 = new VariableLabel()
            {
                data_type = DataType.String,
                form_id = FormId,
                label_name_chs = "客户ID",
                label_config = new LabelConfig()
                {
                    is_parameter = true,
                },
            };

            AddLabel(lb9);

            var lb10 = new VariableLabel()
            {
                data_type = DataType.String,
                form_id = FormId,
                label_name_chs = "区域代码",
                label_config = new LabelConfig()
                {
                    is_parameter = true,
                },
            };

            AddLabel(lb10);

            var lb11 = new VariableLabel()
            {
                form_id = FormId,
                label_name_chs = "楼盘编码",
                data_type = DataType.String,
                label_config = new LabelConfig()
                {

                }
            };
            AddLabel(lb11);

            var lb12 = new VariableLabel()
            {
                form_id = FormId,
                label_name_chs = "楼栋编码",
                data_type = DataType.String,
                label_config = new LabelConfig()
                {

                }
            };
            AddLabel(lb12);

            var lb13 = new VariableLabel()
            {
                form_id = FormId,
                label_name_chs = "房号编码",
                data_type = DataType.String,
                label_config = new LabelConfig()
                {

                }
            };
            AddLabel(lb13);


            var lb14 = new ControlLabel()
            {
                form_id = FormId,
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
            AddLabel(lb14);
        }

        private void LoadFormLables()
        {
            this.LabelList = _labelService.GetLabelList(FormId);
        }

        #endregion
    }
}
