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
        public void AddCodeLabelTest()
        {
            var lb1 = new Label()
            {
                form_id = 1,
                label_name_chs = "楼盘编码",
                data_type = DataType.String,
                label_config = new LabelConfig() { }
            };
            _labelService.AddLabel(lb1, 0);
        }

        [TestMethod()]
        public void AddNameLabelTest()
        {
            var lb1 = new Label() {
                data_type= DataType.String,
                 form_id = 1,
                  label_name_chs = "楼盘名称",
                   label_config = new LabelConfig()
                   {
                        
                   }
            };
            _labelService.AddLabel(lb1, 0);

            var lb2 = new Label()
            {
                data_type = DataType.String,
                form_id = 1,
                label_name_chs = "楼栋名称",
                label_config = new LabelConfig()
                {

                }
            };
            _labelService.AddLabel(lb2, 0);

            var lb3 = new Label()
            {
                data_type = DataType.String,
                form_id = 1,
                label_name_chs = "房号名称",
                label_config = new LabelConfig()
                {
                }
            };
            _labelService.AddLabel(lb3, 0);
            
        }
    }
}