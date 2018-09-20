///////////////////////////////////////////////////////////
//  Form.cs
//  Implementation of the Class Form
//  Generated by Enterprise Architect
//  Created on:      20-9月-2018 14:21:43
//  Original author: drago
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using FD.Tiny.FormBuilder;
namespace FD.Tiny.FormBuilder {
	/// <summary>
	/// 表单类
	/// </summary>
	public class Form {

		/// <summary>
		/// 表单Id
		/// </summary>
		public int form_id{
			get;  set;
		}

		/// <summary>
		/// 表单名称
		/// </summary>
		public string form_name{
			get;  set;
		}

		/// <summary>
		/// 表单描述
		/// </summary>
		public string form_desc{
			get;  set;
		}

		/// <summary>
		/// 分类ID
		/// </summary>
		public int category_id{
			get;  set;
		}

		public Category category{
			get;  set;
		}

		public Map map_config{
			get;  set;
		}

		/// <summary>
		/// 分组列表
		/// </summary>
		public List<FormGroup> group_list{
			get;  set;
		}

		/// <summary>
		/// 参数列表
		/// </summary>
		public List<FormVariable> parameter_list{
			get;  set;
		}

		/// <summary>
		/// 变量列表
		/// </summary>
		public List<FormVariable> variable_list{
			get;  set;
		}

	}//end Form

}//end namespace FD.Tiny.FormBuilder