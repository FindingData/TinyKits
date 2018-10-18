///////////////////////////////////////////////////////////
//  Label.cs
//  Implementation of the Class Label
//  Generated by Enterprise Architect
//  Created on:      18-10月-2018 14:46:03
//  Original author: drago
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using FD.Tiny.FormBuilder;
using FD.Tiny.UI.Controls;
namespace FD.Tiny.FormBuilder {
	/// <summary>
	/// 表单变量
	/// </summary>
	public class Label {

		/// <summary>
		/// 标签Id
		/// </summary>
		public int label_id{
			get;  set;
		}

		/// <summary>
		/// 表单Id
		/// </summary>
		public int form_id{
			get;  set;
		}

		/// <summary>
		/// 数据类型
		/// </summary>
		public DataType data_type{
			get;  set;
		}

		/// <summary>
		/// 标签中文名
		/// </summary>
		public string label_name_chs{
			get;  set;
		}

		/// <summary>
		/// 控件类型
		/// </summary>
		public string control_type{
			get;  set;
		}

		/// <summary>
		/// 默认值
		/// </summary>
		public string default_value{
			get;  set;
		}

		/// <summary>
		/// 标签排序
		/// </summary>
		public int label_sort{
			get;  set;
		}

		/// <summary>
		/// 分组名称
		/// </summary>
		public string group_name{
			get;  set;
		}

		public LabelConfig label_config{
			get;
			set;
		}

		public BaseControl label_control{
			get;
			set;
		}

	}//end Label

}//end namespace FD.Tiny.FormBuilder