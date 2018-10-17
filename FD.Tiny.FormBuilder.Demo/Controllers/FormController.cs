///////////////////////////////////////////////////////////
//  FormController.cs
//  Implementation of the Class FormController
//  Generated by Enterprise Architect
//  Created on:      17-10��-2018 10:25:30
//  Original author: drago
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using System.Web.Mvc;
using FD.Tiny.FormBuilder;
using FD.Tiny.Common.Utility.PageHeler;

namespace FD.Tiny.FormBuilder.Demo.Controllers {
	public class FormController : Controller {

		private FD.Tiny.FormBuilder.FormService _formService;
		private FD.Tiny.FormBuilder.FormStoreService _StoreService;
		private FD.Tiny.FormBuilder.FormVariableService _VariableService;
		private FD.Tiny.FormBuilder.LabelService _labelService;

		/// 
		/// <param name="formService"></param>
		/// <param name="storeService"></param>
		/// <param name="variableService"></param>
		/// <param name="labelService"></param>
		public FormController(FormService formService, FormStoreService storeService, FormVariableService variableService, LabelService labelService){

			_formService = formService;
			_StoreService = storeService;
			_VariableService = variableService;
			_labelService = labelService;
		}

		/// 
		/// <param name="name"></param>
		public ActionResult Index(string name){

			var list = _formService.QueryForm(name);
			return Json(new OkResponse(list), JsonRequestBehavior.AllowGet);
		}

		/// 
		/// <param name="form"></param>
		[HttpPost]
		public ActionResult Add(Form form){

			var result = _formService.AddForm(form,0);
						return Json(new OkResponse(result));
		}

		/// <summary>
		/// GET: Form
		/// </summary>
		/// <param name="formId"></param>
		public ActionResult Get(int formId){

			var result = _formService.GetForm(formId);
						return Json(new OkResponse(result),JsonRequestBehavior.AllowGet);
		}

		/// 
		/// <param name="form"></param>
		[HttpPost]
		public ActionResult Save(Form form){

			_formService.SaveForm(form, 0);
						return Json(new OkResponse());
		}

		public ActionResult Validate(){

			return null;
		}

		/// 
		/// <param name="store"></param>
		[HttpPost]
		public ActionResult Submit(FormStore store){

			_StoreService.SaveFormStore(store, 0);
						return Json(new OkResponse());
		}

		/// 
		/// <param name="storeId"></param>
		public ActionResult Retrieve(int storeId){

			var result = _StoreService.GetFormStore(storeId);
			return Json(new OkResponse(result), JsonRequestBehavior.AllowGet);
		}

		/// 
		/// <param name="variable"></param>
		[HttpPost]
		public ActionResult AddVariable(FormVariable variable){

			var result = _VariableService.AddFormVariabel(variable, 0);
			return Json(new OkResponse(result));
		}

		/// 
		/// <param name="variableId"></param>
		[HttpPost]
		public ActionResult DelVariable(int variableId){

			_VariableService.DelFormVariable(variableId, 0);
			return Json(new OkResponse());
		}

		/// 
		/// <param name="variable"></param>
		[HttpPost]
		public ActionResult SaveVariable(FormVariable variable){

			_VariableService.SaveFormVariable(variable, 0);
			return Json(new OkResponse());
		}

		/// 
		/// <param name="label"></param>
		[HttpPost]
		public ActionResult AddLabel(Label label){

			var result = _labelService.AddLabel(label, 0);
			return Json(new OkResponse(label));
		}

		/// 
		/// <param name="label"></param>
		[HttpPost]
		public ActionResult SaveLabel(Label label){

			_labelService.SaveLabel(label,0);
			return Json(new OkResponse());
		}

		/// 
		/// <param name="labelId"></param>
		[HttpPost]
		public ActionResult DelLabel(int labelId){

			_labelService.DelLabel(labelId, 0);
			return Json(new OkResponse());
		}

       
        public ActionResult GetLabelList(int formId)
        {
            var list = _labelService.GetLabelList(formId);
            return Json(new OkResponse(list),JsonRequestBehavior.AllowGet);
        }

	}//end FormController

}//end namespace Controllers