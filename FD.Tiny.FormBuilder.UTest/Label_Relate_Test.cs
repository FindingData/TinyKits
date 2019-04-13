using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace FD.Tiny.FormBuilder.UTest.Service
{
    /// <summary>
    /// Label_Relate_Test 的摘要说明
    /// </summary>
    [TestClass]
    public class Label_Relate_Test:Label_Base_Test
    {
        
        public Label_Relate_Test():base("测试表单_关联标签")
        {
            
        }       

        [TestMethod]
        public void relate_changed_test()
        {
            var labelList = _labelService.GetLabelList(FormID);
            foreach (var label in labelList
                .Where(l=>l.label_config!=null && l.label_config.relate_list!=null))
            {
                
               
            }

            var l1 = LabelList.FirstOrDefault(l => l.label_name_chs == "物业子类型");
            l1.inner_value = "40002001004";

        }
 
       

        [TestInitialize]
        public void LabelInit()
        {
            InitResidentialLabels();
            var lb1 = new ControlLabel()
            {
                form_id = FormID,
                label_name_chs = "所在楼层",
                data_type = DataType.String,
                label_config = new LabelConfig()
                {
                    control_config = new ControlConfig()
                    {
                        control_type = "input_base",
                    }
                }
            };
            AddLabel(lb1);

            var lb2 = new ControlLabel()
            {
                form_id = FormID,
                label_name_chs = "朝向",
                data_type = DataType.String,
                label_config = new LabelConfig()
                {
                    data_source = new DictSource()
                    {
                        dic_type_id = 30003,
                    },
                    control_config = new ControlConfig()
                    {
                        control_type = "select",
                    }
                }
            };
            AddLabel(lb2);

            var lb3 = new ControlLabel()
            {
                form_id = FormID,
                label_name_chs = "地面装修",
                data_type = DataType.String,
                label_config = new LabelConfig()
                {
                    data_source = new DictSource()
                    {
                        dic_type_id = 30085,
                    },
                    control_config = new ControlConfig()
                    {
                        control_type = "select",                         
                    },
                    relate_list = new List<Relate>()
                    {
                         new ConditionRelate(){ direction_type = DirectionType.reverse,
                          relate_label_name = "物业子类型",
                          relate_type = RelateType.visibility,
                           condition_expr = "@物业子类型 == 40002001004",
                         },
                    }
                }
            };
            AddLabel(lb3);

            var lb4 = new ControlLabel()
            {
                form_id = FormID,
                label_name_chs = "顶棚装修",
                data_type = DataType.String,
                label_config = new LabelConfig()
                {
                    data_source = new DictSource()
                    {
                        dic_type_id = 30087,
                    },
                    control_config = new ControlConfig()
                    {
                        control_type = "select",
                    },
                    relate_list = new List<Relate>()
                    {
                         new ConditionRelate(){ direction_type = DirectionType.reverse,
                          relate_label_name = "物业子类型",
                          relate_type = RelateType.visibility,
                           condition_expr = "@物业子类型 == 40002001004 || @物业子类型 == 40002001005",
                         },
                    }
                }
            };
            base.AddLabel(lb4);            
        }
    }
}
