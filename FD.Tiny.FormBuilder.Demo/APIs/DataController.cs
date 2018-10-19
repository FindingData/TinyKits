using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FD.Tiny.FormBuilder.Demo.APIs
{
    public class DataController : ApiController
    {
        private ApiService _apiService;

        public DataController(ApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet]
        public string Index()
        {
            return "api访问正常";
        }

        [HttpGet]
        public dynamic SingleData(int apiId,List<ApiData> request)
        {            
            return _apiService.GetApiData(apiId, request);
        }


        [HttpGet]
        public dynamic ListData(int apiId, List<ApiData> request)
        {
            return _apiService.GetApiListData(apiId, request);
        }

    }
}
