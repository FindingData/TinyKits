///////////////////////////////////////////////////////////
//  LabelData.cs
//  Implementation of the Class LabelData
//  Generated by Enterprise Architect
//  Created on:      22-10月-2018 16:04:24
//  Original author: drago
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using FD.Tiny.FormBuilder;
namespace FD.Tiny.FormBuilder {
	/// <summary>
	/// 标签数据
	/// </summary>
	public class LabelData {

		/// <summary>
		/// 标签Id
		/// </summary>
		public int lable_id{
			get;  set;
		}

		/// <summary>
		/// 标签值
		/// </summary>
		public dynamic label_value{
			get;  set;
		}

		public string label_name_chs{
			get;
			set;
		}

		public Label label{
			get;
			set;
		}

	}//end LabelData

}//end namespace FD.Tiny.FormBuilder