using FD.Tiny.Common.Utility.PageHeler;
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
        private DictService _dictService;

        public DataController(ApiService apiService,
            DictService dictService)
        {
            _apiService = apiService;
            _dictService = dictService;
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

        [HttpGet]
        public IHttpActionResult GetDictListAll()
        {
            var result = _dictService.GetCacheDictList();
            return Json(new OkResponse(result));
        }

        [HttpGet]
        public IHttpActionResult GetDictList(int dicTypeId)
        {
            var result= _dictService.GetDictList(dicTypeId);
            return Json(new OkResponse(result));
        }               
    }
}
