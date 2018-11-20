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
            var list = _apiService.GetApiListData(21, request);
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
            var api = new Api()
            {
                api_name = "获取楼盘",
                api_url = "",
                api_desc = "",
                sql_content = "select c.construction_code,c.construction_name from redas.t_construction c where rownum < 10 ",
            };
            _apiService.AddApi(api, 0);
        }

        [TestMethod()]
        public void SaveApiTest()
        {
            Assert.Fail();
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
            list.ForEach(l => Console.WriteLine(l.parameter_name + " || " + l.parameter_name_chs));
            //Assert.Fail();
        }

        [TestMethod()]
        public void GetResponseParamsFromSqlTest()
        {
            var sql = "select c.construction_code,c.construction_name from redas.t_construction c where construction_code=@construction_code rownum < 10";
            var list = _apiService.GetResponseParamsFromSql(sql);
            list.ForEach(l => Console.WriteLine(l.parameter_name + " || " + l.parameter_name_chs));
        }
    }
}