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
            IList<BaseControl> inputs = new List<BaseControl>();
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
                url = "/home/api",
            };
            search.autocomplete = autocomplete;
           

            return Json(inputs, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Index(IList<BaseControl> controls)
        {
            return View();
        }
        
        public ActionResult Api()
        {
            
            return View();
        }

        
    }
}