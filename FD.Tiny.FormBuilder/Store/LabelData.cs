///////////////////////////////////////////////////////////
//  LabelData.cs
//  Implementation of the Class LabelData
//  Generated by Enterprise Architect
//  Created on:      20-9月-2018 12:05:55
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

		public Label label{
			get;
			set;
		}

	}//end LabelData

}//end namespace FD.Tiny.FormBuilder