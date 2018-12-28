using FD.Tiny.Common.Utility.PageHeler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FD.Tiny.FormBuilder.Demo.APIs
{
    public class LabelController : ApiController
    {
        private LabelService _labelService;
        public LabelController(LabelService labelService)
        {
            _labelService = labelService;
        }

        [HttpPost]
        public BaseResponse  AddLabel(Label label)
        {           
            var result = _labelService.AddLabel(label, 0);
            return new OkResponse(result);
        }

        
    }
}
