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
    public class ApiServiceTests : BaseTest
    {

        ApiService _apiService;

        public ApiServiceTests()
        {
            _apiService = AutofacExt.GetFromFac<ApiService>();

        }

        [TestMethod()]
        public void GetApiDataTest()
        {
            List<ApiData> request = new List<ApiData>();
            request.Add(new ApiData()
            {
                 parameter_name = "CUSTOMER_ID",
                  value = "3",
            });
            var list = _apiService.GetApiListData(81, request);
            Assert.IsNotNull(list);
        }

        [TestMethod()]
        public void GetApiListDataTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddApiTest()
        {
            //var api = new Api()
            //{
            //    api_name = "获取楼盘",
            //    api_url = "",
            //    api_desc = "",
            //    sql_content = "SELECT c.construction_code, c.construction_name FROM redas.t_construction c WHERE c.new_purpose_id = @new_purpose_Id and c.pca_code = @pca_code and  c.customer_id = @customer_id and rownum< 10 ",
            //};
            var api = new Api()
            {
                api_name = "获取楼栋",
                api_url = "",
                api_desc = "",
                sql_content = @"SELECT b.building_code, b.building_name
  FROM redas.t_building b
 WHERE b.construction_code = @construction_code
   and b.pca_code = @pca_code
   and b.customer_id = @customer_id
   and rownum < 10",
            };
            _apiService.AddApi(api, 0);
        }

        [TestMethod()]
        public void SaveApiTest()
        {
            var api = _apiService.GetApi(61);
            //api.sql_content = "SELECT c.construction_code, c.construction_name FROM redas.t_construction c WHERE c.new_purpose_id = @new_purpose_Id and c.pca_code = @pca_code and  c.customer_id = @customer_id and rownum< 10 ";
            api.request_parameter_list = _apiService.GetRequestParamsFromSql(api.sql_content);
            api.response_parameter_list = _apiService.GetResponseParamsFromSql(api.sql_content);
            _apiService.SaveApi(api, 0);            
        }

        [TestMethod()]
        public void DelApiTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void QueryApiTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetApiTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetRequestParamsFromSqlTest()
        {
            var sql = "select c.construction_code,c.construction_name from redas.t_construction c where rownum < 10";
            var list = _apiService.GetRequestParamsFromSql(sql);
            var paramList = new List<string>();            
            list.ForEach(l => {
                paramList.Add(l.parameter_name);    
                Console.WriteLine(l.parameter_name + " || " + l.parameter_name_chs); });
          
            Assert.AreEqual("construction_code,construction_name", string.Join(",", paramList));
        }

        [TestMethod()]
        public void GetResponseParamsFromSqlTest()
        {
            var sql = "select c.construction_code,c.construction_name from redas.t_construction c where construction_code=@construction_code and construction_name like '%@construction_name%' rownum < 10";
            var list = _apiService.GetResponseParamsFromSql(sql);
            var paramList = new List<string>();
            list.ForEach(l => {
                paramList.Add(l.parameter_name);
                Console.WriteLine(l.parameter_name + " || " + l.parameter_name_chs);
            });
            Assert.AreEqual("construction_code,construction_name", string.Join(",", paramList));
        }
    }
}