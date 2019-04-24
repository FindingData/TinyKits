using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using FD.Tiny.FormBuilder.UTest.Init;

namespace FD.Tiny.FormBuilder.UTest
{
    /// <summary>
    /// API_Test 的摘要说明
    /// </summary>
    [TestClass]
    public class API_Test:BaseTest
    {
        public ApiService _apiService { get; set; }        

        public API_Test()
        {
            //
            //TODO:  在此处添加构造函数逻辑
            //
        }            


      
        [TestMethod]
        public void GetConstructionApiTest()
        {
            var api = _apiService.GetApi("获取楼盘");
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
            var list = _apiService.GetApiListData(api.api_id, request);
            Assert.IsNotNull(list);
        }
    }
}
