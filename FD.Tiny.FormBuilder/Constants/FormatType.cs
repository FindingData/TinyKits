///////////////////////////////////////////////////////////
//  FormatType.cs
//  Implementation of the Enumeration FormatType
//  Generated by Enterprise Architect
//  Created on:      20-9月-2018 10:09:40
//  Original author: drago
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



namespace FD.Tiny.FormBuilder {
	/// <summary>
	/// 格式化类型
	/// </summary>
	public enum FormatType : int {

		/// <summary>
		/// 数字转换
		/// </summary>
		Number,
		/// <summary>
		/// 时间转换
		/// </summary>
		Date,
		/// <summary>
		/// 数据源转换
		/// </summary>
		DataSource
	}//end FormatType

}//end namespace FD.Tiny.FormBuilder