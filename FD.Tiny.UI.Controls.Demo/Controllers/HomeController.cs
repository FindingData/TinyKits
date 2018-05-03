using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FD.Tiny.UI.Controls;

namespace FD.Tiny.UI.Controls.Demo.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {

            var ctls = new List<BaseControl>();

            var radio = new Radio()
            {
                name = "radio",                
            };
             
            var checkexbox = new CheckBox()
            {
                name = "checkbox",
                is_checked = true,
            };

            var uncheckedbox = new CheckBox() {
                name = "chexkbox",                
            };

            var datePicker = new DatePicker()
            {

            };


            
            return Json(ctls, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult Input()
        {
            
            var text = new Input()
            {
                name = "input",
                mode = InputMode.text,
                placeholder = "文本"
            };

            var textarea = new Input()
            {
                name = "textarea",
                placeholder = "文本域",
                mode = InputMode.textarea,                 
            };

            var search = new Input()
            {
                name = "search",
                mode = InputMode.text,
            };

            var autocomplete = new Autocomplete()
            {
                url = "/home/api/getuser",
                param_list = new List<QueryParam>()
                {
                     new QueryParam(){ name="customer_id",value="1" },
                     new QueryParam(){ name="user_id",value="2"},
                },
                 response_formatter= new ResultFormatter()
                 {
                     label = "user_name",
                     value = "user_id"
                 }
            };
            search.autocomplete = autocomplete;

            IList<BaseControl> inputs = new List<BaseControl>() {
                text,
                textarea,
                search
            };

            return Json(inputs, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Select()
        {


            return Json("", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Index(IList<BaseControl> controls)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Api(string method)
        {
            if (method == "getuser")
            {
                var user1 = new
                {
                    user_name = "abc",
                    user_id = "123"
                };
                var list = Enumerable.Repeat(user1, 5).ToList();
                return Json(list);
            }
            return Json(null);
        }

        
    }
}