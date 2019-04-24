using Microsoft.VisualStudio.TestTools.UnitTesting;
using FD.Tiny.FormBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FD.Tiny.FormBuilder.UTest;

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
        public void GetRequestParamsFromSqlTest()
        {
            var sql = "select c.construction_code,c.construction_name from redas.t_construction c where rownum < 10";
            var list = ApiService.GetRequestParamsFromSql(sql);
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
            var list = ApiService.GetResponseParamsFromSql(sql);
            var paramList = new List<string>();
            list.ForEach(l => {
                paramList.Add(l.parameter_name);
                Console.WriteLine(l.parameter_name + " || " + l.parameter_name_chs);
            });
            Assert.AreEqual("construction_code,construction_name", string.Join(",", paramList));
        }
    }
}