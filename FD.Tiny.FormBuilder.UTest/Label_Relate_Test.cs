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
            var labelList = _labelService.GetLabelList(FormId);
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
        }
    }
}
