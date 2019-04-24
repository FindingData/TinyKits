using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FD.Tiny.FormBuilder.UTest
{
    [TestClass]
    public class Form_Base_Test:BaseTest
    {               
        public FormService _formService { get; set; }
        public LabelService _labelService { get; set; }
        public FormStoreService _formStoreService { get; set; }

          
        public Form_Base_Test()
        {                      
          
        }

       
        //public LabelData AddLabelData(string labelName, string value)
        //{
        //    var ldata = new LabelData();
        //    var label = LabelList.FirstOrDefault(l => l.label_name_chs == labelName);
        //    if (label == null)
        //        throw new ArgumentException("label not exist.");
        //    ldata.label_id = label.label_id;
        //    ldata.label_name_chs = labelName;
        //    ldata.label_value = value;
        //    return ldata;
        //}

        //public void SubmitForms(List<LabelData> dataList)
        //{
        //    var store = new FormStore();
        //    store.form_id = FormId;
        //    store.customer_id = CustomerId;
        //    store.label_data_list = dataList;
        //    StoreId = _formService.Submit(store, 0);
        //}             
      
    }
}
