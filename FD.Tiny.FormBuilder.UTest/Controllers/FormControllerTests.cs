using Microsoft.VisualStudio.TestTools.UnitTesting;
using FD.Tiny.FormBuilder.Demo.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Tiny.FormBuilder.Demo.Controllers.Tests
{
    [TestClass()]
    public class FormControllerTests
    {
        FormController _controller;


        public FormControllerTests()
        {
            _controller = new FormController(AutofacExt.GetFromFac<FormService>(),
                AutofacExt.GetFromFac<FormStoreService>(), AutofacExt.GetFromFac<LabelService>());
        }

        [TestMethod()]
        public void FormControllerTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void IndexTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SaveTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ValidateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SubmitTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RetrieveTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RetrieveDbDataTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddLabelTest()
        {
            var lb = new ControlLabel()
            {
                form_id = 81,
                label_name_chs = "文本测试",
                data_type = DataType.String,
                form = null,
                inner_value = "",
                label_type = LabelType.condition,
                label_config = new ControlConfig()
                {
                    control_type = "input",
                    label_sort = 1,
                    group_name = "基础",
                    validator_config = new ValidatorConfig(),
                    data_source_config = new DataSource(),
                    relate_config = new RelateConfig(),
                    database_config = null,
                    map_config = null,
                    control_options = new List<Option>()
                       {
                            new Option(){ key = "placeholder",value= "你好"},
                            new Option(){ key="readonly", value = false},
                       }
                },
            };
            _controller.AddLabel(lb);
        }

        [TestMethod()]
        public void SaveLabelTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DelLabelTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetLabelListTest()
        {
            Assert.Fail();
        }
    }
}