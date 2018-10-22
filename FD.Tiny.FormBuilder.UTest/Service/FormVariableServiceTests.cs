﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using FD.Tiny.FormBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FD.Tiny.FormBuilder.UTest;
using FD.Tiny.FormBuilder.Demo;

namespace FD.Tiny.FormBuilder.Tests
{
    [TestClass()]
    public class FormVariableServiceTests : BaseTest
    {
        private FormVariableService _formVariableService;

        
        public  FormVariableServiceTests()
        {
            _formVariableService = AutofacExt.GetFromFac<FormVariableService>();
        }

        [TestMethod]
        public void AddFormVariabel()
        {
            var variable = new FormVariable();

            variable.database_config = new DatabaseConfig()
            {
                column_name = "column_name",
                table_name = "t_col",
            };
            variable.form_id = 1;
            variable.variable_name = "abc";
            variable.variable_name_chs = "你";
            variable.data_type = DataType.String;
            variable.default_value = "column_name";
            _formVariableService.AddFormVariabel(variable, 0);           
        }

    }
}