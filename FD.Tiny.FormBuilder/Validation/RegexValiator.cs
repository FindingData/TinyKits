///////////////////////////////////////////////////////////
//  RegexValiator.cs
//  Implementation of the Class RegexValiator
//  Generated by Enterprise Architect
//  Created on:      20-9月-2018 14:14:18
//  Original author: drago
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using FD.Tiny.FormBuilder;
namespace FD.Tiny.FormBuilder {
	/// <summary>
	/// 正则验证
	/// </summary>
	public class RegexValiator : BaseValidator {

		/// <summary>
		/// 正则表达式
		/// </summary>
		public string regex_pattern{
			get;  set;
		}

	}//end RegexValiator

}//end namespace FD.Tiny.FormBuilder