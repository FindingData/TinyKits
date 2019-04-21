using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace FD.Tiny.FormBuilder.UTest
{
    /// <summary>
    /// API_Test 的摘要说明
    /// </summary>
    [TestClass]
    public class API_Test:API_Base_Test
    {
       
        public API_Test()
        {
            //
            //TODO:  在此处添加构造函数逻辑
            //
        }

   
         

      
        [TestMethod]
        public void GetConstructionApiTest()
        {
            List<ApiData> request = new List<ApiData>();
            request.Add(new ApiData()
            {
                parameter_name = "CUSTOMER_ID",
                value = "3",
            });
            request.Add(new ApiData()
            {
                parameter_name = "PCA_CODE",
                value = "430100",
            });
            request.Add(new ApiData()
            {
                parameter_name = "NEW_PURPOSE_ID",
                value = "40002001"
            });
            var list = _apiService.GetApiListData(21, request);
            Assert.AreEqual(10,list.Count());
        }
    }
}
