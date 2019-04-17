using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace FD.Tiny.FormBuilder.UTest
{
    [TestClass]
    public class Form_Test_Business : Label_Base_Test
    {         
        public Form_Test_Business() : base("测试表单_业务表单")
        {

        }


        //初始化标签
        [TestInitialize]
        public void FormInit()
        {
            this.InitBusinessLables();
            FormStoreInit();
        }

        [TestMethod]
        public void DatabaseSqlTest()
        {
            var dbDataList = _formService.RetriveDbData(StoreId);
            foreach (var dbData in dbDataList)
            {
                 Console.WriteLine($"t:{dbData.table_name}---c:{dbData.column_name}----v:{dbData.column_value}");
            }

        }

        private void FormStoreInit()
        {
            var dataList = new List<LabelData>();
            dataList.Add(AddLabelData("贷款类型", "40047001"));
            dataList.Add(AddLabelData("详细预估", "1"));
            dataList.Add(AddLabelData("客户经理", "4"));
            dataList.Add(AddLabelData("借款人", "黄波"));
            dataList.Add(AddLabelData("借款人电话", "13456781234"));
            base.SubmitForms(dataList);
        }
        
    }
}
