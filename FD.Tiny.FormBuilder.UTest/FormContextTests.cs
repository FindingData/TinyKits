using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FD.Tiny.FormBuilder.UTest
{
    [TestClass]
    public class FormContextTests
    {
        FormBuilderContent dbContext;


        public FormContextTests() {
            dbContext = new FormBuilderContent();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            
        }

        [TestMethod]
        public void ApiAddTest()
        {
            var api = new ApiPO();
            api.API_NAME = "test";
            api.CREATED_BY = 1;
            api.API_URL = "http://www.baidu.com";
            api.SQL_CONTENT = "select * from t_api";
            dbContext.Apis.Add(api);
            dbContext.SaveChanges();            
        }

        [TestMethod]
        public void DbTableAddTest()
        {
            var table = new DbTablePO();
            table.TABLE_NAME = "t_db_table";
            table.SCHEMA_NAME = "form";
            table.TABLE_NAME_CHS = "数据库表";
            table.CREATED_BY = 1;
            dbContext.Tables.Add(table);
            dbContext.SaveChanges();
        }

        [TestMethod]
        public void DbColumnAddTest()
        {
            var col = new DbColumnPO();
            col.TABLE_ID = 1; //已添加
            col.COLUMN_NAME = "table_name";
            col.COLUMN_NAME_CHS = "表名称";
            col.CREATED_BY = 1;
            col.DATA_TYPE = (decimal)DataType.String;
            col.LENGTH = 100;
            dbContext.Columns.Add(col);
            dbContext.SaveChanges();
        }

        //[TestMethod]
        //public void CategoryAddTest()
        //{
        //    var cat = new CategoryPO();
        //    cat.CATEGORY_NAME = "查勘表";
        //    cat.CREATED_BY = 1;
        //    cat.CUSTOMER_ID = 1;
        //    dbContext.Categories.Add(cat);
        //    dbContext.SaveChanges();
        //}

        [TestMethod]
        public void FormAddTest()
        {
            var form = new FormPO();
            form.CATEGORY_ID = 1;
            form.FORM_NAME = "查勘表";
            form.VERSION_NO = 0.1m;            
            form.CREATED_BY = 1;
            dbContext.Forms.Add(form);
            dbContext.SaveChanges();
        }

        [TestMethod]
        public void FormVariableAddTest()
        {
            var formVar = new FormVariablePO();
            formVar.FORM_ID = 1;
            formVar.VARIABLE_NAME = "object_name";
            formVar.IS_PARAMETER = 0;
            formVar.VARIABLE_NAME_CHS = "标的名称";
            formVar.DATA_TYEP = (decimal)DataType.String;
            dbContext.FormVariables.Add(formVar);
            dbContext.SaveChanges();
        }

        [TestMethod]
        public void LabelAddTest()
        {
            var label = new LabelPO();
            label.FORM_ID = 1;
            label.LABEL_NAME_CHS = "楼盘名称";
            label.GROUP_NAME = "实物因素";
            label.CREATED_BY = 1;
            label.DATA_TYPE = (decimal)DataType.String;
            label.LABEL_SORT = 1;
            dbContext.Labels.Add(label);
            dbContext.SaveChanges();
        }

        [TestMethod]
        public void FormStoreAddTest()
        {
            var store = new FormStorePO();
            store.FORM_ID = 1;
            store.CREATED_BY = 1;            
            store.CUSTOMER_ID = 1;
            dbContext.FormStores.Add(store);
            dbContext.SaveChanges();
        }

    }

    
}
