///////////////////////////////////////////////////////////
//  FormController.cs
//  Implementation of the Class FormController
//  Generated by Enterprise Architect
//  Created on:      15-10��-2018 10:40:30
//  Original author: drago
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using System.Web.Mvc;
using FD.Tiny.FormBuilder;
namespace FD.Tiny.FormBuilder.Demo.Controllers {
	public class FormController : Controller {

		public ActionResult Index(){

			return null;
		}

		/// 
		/// <param name="form"></param>
		public ActionResult Add(Form form){

			return null;
		}

		/// <summary>
		/// GET: Form
		/// </summary>
		/// <param name="formId"></param>
		public ActionResult Get(int formId){

			return View();
		}

		/// 
		/// <param name="form"></param>
		public ActionResult Save(Form form){

			return null;
		}

		public ActionResult Serach(){

			return null;
		}

		public ActionResult Validate(){

			return null;
		}

		/// 
		/// <param name="store"></param>
		public ActionResult Submit(FormStore store){

			return null;
		}

		/// 
		/// <param name="storeId"></param>
		public ActionResult Retrieve(FormStore storeId){

			return null;
		}

		public ActionResult AddVariable(){

			return null;
		}

		public ActionResult DelVariable(){

			return null;
		}

		public ActionResult SaveVariable(){

			return null;
		}

		public ActionResult AddLabel(){

			return null;
		}

		public ActionResult SaveLabel(){

			return null;
		}

		public ActionResult DelLabel(){

			return null;
		}

	}//end FormController

}//end namespace Controllers