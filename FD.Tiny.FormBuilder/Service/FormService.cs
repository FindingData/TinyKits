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
using AutoMapper;
using System.Linq;

namespace FD.Tiny.FormBuilder {
	public class FormService : BaseService<FormPO> {

        private FormStoreService _formStoreService;
        private FormVariableService _formVariableService;
        private LabelService _labelService;

        public FormService(IRepository<FormPO> repository,
            FormStoreService formStoreService,
            FormVariableService formVariableService,
            LabelService labelService) : base(repository)
        {
            _formStoreService = formStoreService;
            _formVariableService = formVariableService;
            _labelService = labelService;
        }


        public Form BuildForm(int formId)
        {
            var form = GetForm(formId);
            form.variable_list = _formVariableService.GetFormVariableList(formId);            
            var labelList = _labelService.GetLabelList(formId);
            //var labelGroup = labelList.GroupBy(l => l.group_name);
            foreach (var group in form.group_list)
            {
                //group.label_list = labelGroup.Single(l => l.Key == group.group_name).ToList();
                group.label_list = labelList.Where(l => l.group_name == group.group_name).ToList();
            }                      
            return form;
        }

        public List<DbData> RetriveDbData(int storeId)
        {
            List<DbData> dataList = new List<DbData>();
            var store = _formStoreService.GetFormStore(storeId);
            if (store == null)
                return null;
            var variableList = _formVariableService.GetFormVariableList(store.form_id);

            foreach (var dbVariable in variableList.Where(v => v.database_config != null))
            {
                var value = store.form_data_list.FirstOrDefault(d => d.variable_id == dbVariable.variable_id)?.variable_value;
                var data = new DbData()
                {
                    column_name = dbVariable.database_config.table_name,
                    table_name = dbVariable.database_config.column_name,
                    column_value = value,
                };
                dataList.Add(data);
            }
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
            return Mapper.Map<FormPO, Form>(formPo); ;
        }

        public List<Form> QueryForm(string name)
        {
            var list = Repository.Find(r => r.FORM_NAME.Contains(name)).ToList();
            return Mapper.Map<List<FormPO>, List<Form>>(list);
        }

	}//end FormService

}//end namespace FD.Tiny.FormBuilder