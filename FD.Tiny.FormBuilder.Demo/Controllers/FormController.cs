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


using FD.Tiny.FormBuilder;
using FD.Tiny.Common.Utility.PageHeler;
using System.Web.Http;

namespace FD.Tiny.FormBuilder.Demo.Controllers {
	public class FormController : ApiController {

		private FD.Tiny.FormBuilder.FormService _formService;
		private FD.Tiny.FormBuilder.FormStoreService _StoreService;
		//private FD.Tiny.FormBuilder.FormVariableService _VariableService;
		private FD.Tiny.FormBuilder.LabelService _labelService;

		/// 
		/// <param name="formService"></param>
		/// <param name="storeService"></param>
		/// <param name="variableService"></param>
		/// <param name="labelService"></param>
		public FormController(FormService formService, FormStoreService storeService,
            //FormVariableService variableService,
            LabelService labelService){

			_formService = formService;
			_StoreService = storeService;
			//_VariableService = variableService;
			_labelService = labelService;
		}

        /// 
        /// <param name="name"></param>
        [HttpGet]
        public IHttpActionResult Index(string name){

			var list = _formService.QueryForm(name);
			return Json(new OkResponse(list));
		}

        /// 
        /// <param name="form"></param>
        [HttpPost]
        public IHttpActionResult Add(Form form)
        {

            var result = _formService.AddForm(form, 0);
            return Json(new OkResponse(result));
        }

        /// <summary>
        /// GET: Form
        /// </summary>
        /// <param name="formId"></param>
        [HttpGet]
        public IHttpActionResult Get(int formId)
        {
            var result = _formService.GetForm(formId);
            return Json(new OkResponse(result));
        }

        /// 
        /// <param name="form"></param>
        [HttpPost]
        public IHttpActionResult Save(Form form)
        {

            _formService.SaveForm(form, 0);
            return Json(new OkResponse());
        }

		public IHttpActionResult Validate(){

			return null;
		}

        /// 
        /// <param name="store"></param>
        [HttpPost]
        public IHttpActionResult Submit(FormStore store)
        {
            var result = _StoreService.AddFormStore(store, 0);

            return Json(new OkResponse(result));
        }

        /// 
        /// <param name="storeId"></param>
        [HttpGet]
        public IHttpActionResult Retrieve(int storeId){

			var result = _StoreService.GetFormStore(storeId);
			return Json(new OkResponse(result));
		}

        [HttpGet]
        public IHttpActionResult RetrieveDbData(int storeId)
        {
            var result = _formService.RetriveDbData(storeId);
            return Json(new OkResponse(result));
        }

       

		/// 
		/// <param name="label"></param>
		[HttpPost]
		public IHttpActionResult AddLabel(Label label){

			var result = _labelService.AddLabel(label, 0);
           
			return Json(new OkResponse(result));
		}

		/// 
		/// <param name="label"></param>
		[HttpPost]
		public IHttpActionResult SaveLabel(Label label){

			_labelService.SaveLabel(label,0);
			return Json(new OkResponse());
		}

		/// 
		/// <param name="labelId"></param>
		[HttpGet]
		public IHttpActionResult DelLabel(int labelId){

			_labelService.DelLabel(labelId, 0);
			return Json(new OkResponse());
		}

       
        public IHttpActionResult GetLabelList(int formId)
        {
            var list = _labelService.GetLabelList(formId);
            return Json(new OkResponse(list));
        }

	}//end FormController

}//end namespace Controllers