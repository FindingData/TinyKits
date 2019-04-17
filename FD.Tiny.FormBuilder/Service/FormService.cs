///////////////////////////////////////////////////////////
//  FormService.cs
//  Implementation of the Class FormService
//  Generated by Enterprise Architect
//  Created on:      30-9��-2018 8:56:20
//  Original author: drago
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using FD.Tiny.FormBuilder;
using FD.Tiny.Common.Utility.Extensions;
using AutoMapper;
using System.Linq;

namespace FD.Tiny.FormBuilder {
	public class FormService : BaseService<FormPO> {

        private FormStoreService _formStoreService;
        
        private LabelService _labelService;

        public FormService(IRepository<FormPO> repository,
            FormStoreService formStoreService,        
            LabelService labelService) : base(repository)
        {
            _formStoreService = formStoreService;
        
            _labelService = labelService;
        }


        public Form BuildForm(int formId,Dictionary<string,string> initParams)
        {
            var form = GetForm(formId);

            form.form_params = initParams;

            var labelList = _labelService.GetLabelList(formId);            
            
            foreach (var label in labelList)
            {              
                form.AddLabel(label);
            }
            
            return form;
        }

        public int Submit(FormStore store,int userId)
        {
            Dictionary<string, object> labelDataList = store.label_data_list.ToDictionary(k => k.label_name_chs, v => v.label_value);
            
            var variables = _labelService.GetLabelList(store.form_id);

            foreach (var variable in variables)
            {
                if(!(variable is ControlLabel))
                {
                    var labelData = new LabelData()
                    {
                        label_id = variable.label_id,
                        label_name_chs = variable.label_name_chs,
                        label_value = variable.GetValue(r => labelDataList.GetOrDefault(r, ""))
                    };
                    store.label_data_list.Add(labelData);
                }               
            }           
           return  _formStoreService.AddFormStore(store, userId);
        }        
       
        public List<DbData> RetriveDbData(int storeId)
        {
            List<DbData> dataList = new List<DbData>();
            var store = _formStoreService.GetFormStore(storeId);
            if (store == null)
                return null;
            var labelList = _labelService.GetLabelList(store.form_id);
            foreach (var label in labelList.Where(f=>f.label_config.database_config!=null))
            {
                var val = store.label_data_list.FirstOrDefault(d=>d.label_id == label.label_id);
                dataList.Add(new DbData()
                {
                    column_name = label.label_config.database_config.column_name,
                    column_value = val?.label_value,
                    table_name = label.label_config.database_config.table_name,
                });
            }
            return dataList;
        }

        public List<LabelData> CopyFormData(int formId,int storeId)
        {
            List<LabelData> dataList = new List<LabelData>();
            var formList = _labelService.GetLabelList(formId);
            return dataList;
        }

        /// 
        /// <param name="form"></param>
        /// <param name="userId"></param>
        public int AddForm(Form form, int userId)
        {
            var formPo = Mapper.Map<Form, FormPO>(form);
            Repository.Add(formPo, userId);
            return (int)formPo.FORM_ID;
        }

        /// 
        /// <param name="form"></param>
        /// <param name="userId"></param>
        public void SaveForm(Form form, int userId)
        {            
            var formPo = Mapper.Map<Form, FormPO>(form);
            Repository.Update(formPo, userId);            
        }

        /// 
        /// <param name="formId"></param>
        /// <param name="userId"></param>
        public void DelForm(int formId, int userId)
        {
            var formPo = Repository.FindSingle(r => r.FORM_ID == formId);
            Repository.SoftDelete(formPo, userId);
        }

        /// 
        /// <param name="formId"></param>
        public Form GetForm(int formId)
        {
            var formPo = Repository.FindSingle(r => r.FORM_ID == formId);
            return Mapper.Map<FormPO, Form>(formPo);
        }

        public Form GetForm(string formName)
        {
            var formPo = Repository.FindSingle(r => r.FORM_NAME == formName);
            return Mapper.Map<FormPO, Form>(formPo); 
        }

        public List<Form> QueryForm(string name)
        {
            var list = Repository.Find(r => string.IsNullOrEmpty(name) || r.FORM_NAME.Contains(name)).ToList();
            return Mapper.Map<List<FormPO>, List<Form>>(list);
        }

	}//end FormService

}//end namespace FD.Tiny.FormBuilder