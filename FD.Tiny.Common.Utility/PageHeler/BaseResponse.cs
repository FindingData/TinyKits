using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace FD.Tiny.Common.Utility.PageHeler
{
    public class FailResponse : BaseResponse
    {
        public FailResponse()
        {
            this.Status = false;
        }

        public FailResponse(string msg) : this()
        {
            this.Message = msg;
        }
    }

    public class OkResponse : BaseResponse
    {
        public OkResponse()
        {
            this.Status = true;
            this.Message = "操作成功";
        }

        public OkResponse(dynamic result) : this()
        {
            this.Result = result;
        }
    }

    public class BaseResponse 
    {
        public BaseResponse()
        {
        }

        public BaseResponse(bool status, dynamic result, string message)
        {
            this.Status = status;
            this.Result = result;
            this.Message = message;
        }

        public bool Status { get; set; }

        public string Message { get; set; } = "操作成功";

        public dynamic Result { get; set; }
       
    }
}
