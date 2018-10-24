///////////////////////////////////////////////////////////
//  FormVariable.cs
//  Implementation of the Class FormVariable
//  Generated by Enterprise Architect
//  Created on:      23-10月-2018 9:05:44
//  Original author: drago
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using FD.Tiny.FormBuilder;
namespace FD.Tiny.FormBuilder {
	public class FormVariable {

		/// <summary>
		/// 变量Id
		/// </summary>
		public int variable_id{
			get;  set;
		}

		/// <summary>
		/// 表单Id
		/// </summary>
		public int form_id{
			get;  set;
		}

		/// <summary>
		/// 变量名称
		/// </summary>
		public string variable_name_chs{
			get;  set;
		}

		/// <summary>
		/// 默认值
		/// </summary>
		public dynamic default_value{
			get;  set;
		}

		/// <summary>
		/// 数据类型
		/// </summary>
		public DataType data_type{
			get;  set;
		}

		/// <summary>
		/// 是否参数
		/// </summary>
		public bool is_parameter{
			get;  set;
		}

		/// <summary>
		/// 数据配置
		/// </summary>
		public DatabaseConfig database_config{
			get;  set;
		}

		public VariableType variable_type{
			get;
			set;
		}

        public FormVariable()
        {
            this.variable_type = VariableType.Variable;
        }

        /// <summary>
        /// 获取值
        /// </summary>
        /// <returns></returns>
        public virtual string GetValue(Func<string,string> getVal)
        {
            return this.default_value;
        }         

	}//end FormVariable

}//end namespace Variable