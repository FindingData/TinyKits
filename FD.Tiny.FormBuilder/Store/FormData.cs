///////////////////////////////////////////////////////////
//  FormData.cs
//  Implementation of the Class FormData
//  Generated by Enterprise Architect
//  Created on:      20-9��-2018 12:07:02
//  Original author: drago
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using FD.Tiny.FormBuilder;
namespace FD.Tiny.FormBuilder {
	/// <summary>
	/// ��������
	/// </summary>
	public class FormData {

		/// <summary>
		/// ����Id
		/// </summary>
		public int variable_id{
			get;  set;
		}

		/// <summary>
		/// ����ֵ
		/// </summary>
		public dynamic variable_value{
			get;  set;
		}

		public FormVariable form_variable{
			get;
			set;
		}

	}//end FormData

}//end namespace FD.Tiny.FormBuilder