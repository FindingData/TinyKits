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

        public class PostModel {
            public int apiId { get; set; }

            public List<ApiData> request { get; set; }
        }

        [HttpPost]
        public IHttpActionResult SingleData(PostModel postModel)
        {
            var result = _apiService.GetApiData(postModel.apiId, postModel.request);
            return Json(new OkResponse(result));
        }


        [HttpPost]
        public IHttpActionResult ListData(PostModel postModel)
        {
            var result = _apiService.GetApiListData(postModel.apiId, postModel.request);
            return Json(new OkResponse(result));
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
            var result = _dictService.GetDictList(dicTypeId);
            return Json(new OkResponse(result));
        }      
        
        [HttpGet]
        public IHttpActionResult GetDictTypeList()
        {
            var result = _dictService.GetDictTypeList();
            return Json(new OkResponse(result));
        }
    }
}
