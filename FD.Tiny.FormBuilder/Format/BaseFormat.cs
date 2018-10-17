///////////////////////////////////////////////////////////
//  BaseFormat.cs
//  Implementation of the Class BaseFormat
//  Generated by Enterprise Architect
//  Created on:      20-9��-2018 10:25:03
//  Original author: drago
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



namespace FD.Tiny.FormBuilder {
	/// <summary>
	/// ��ʽ������
	/// </summary>
	public abstract class BaseFormat {

		/// <summary>
		/// ��ʽ���ַ���
		/// </summary>
		public string format_str{
			get;  set;
		}

		/// <summary>
		/// ��ʽ������
		/// </summary>
		public FormatType format_type{
			get;  set;
		}

		/// <summary>
		/// ��ʽ��ֵ
		/// </summary>
		public dynamic value{
			get;  set;
		}

		/// <summary>
		/// ��ʽ�����
		/// </summary>
		public string result{
			get;  set;
		}

	}//end BaseFormat

}//end namespace FD.Tiny.FormBuilder