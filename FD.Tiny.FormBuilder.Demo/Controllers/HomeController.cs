using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FD.Tiny.FormBuilder.Demo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult FormEdit(int formId)
        {
            return View();
        }
        public ActionResult FormEditOld(string formKey)
        {
            return View();
        }
        public ActionResult FormPreview(string formKey)
        {
            return View();
        }
    }
}