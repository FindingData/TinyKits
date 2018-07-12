///////////////////////////////////////////////////////////
//  ControlType.cs
//  Implementation of the Enumeration ControlType
//  Generated by Enterprise Architect
//  Created on:      29-4月-2018 11:57:25
//  Original author: drago
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



namespace FD.Tiny.UI.Controls {
	public enum ControlType : int {

		/// <summary>
		/// 输入框
		/// </summary>
		input,
        /// <summary>
        /// 数值输入框
        /// </summary>
        inputNumber,
        /// <summary>
        /// 时间框
        /// </summary>
		datePicker,
		/// <summary>
		/// 选择器
		/// </summary>
		select,
		/// <summary>
		/// 多选框
		/// </summary>
		checkbox,
		/// <summary>
		/// 单选框
		/// </summary>
		radio

	}//end ControlType

}//end namespace FD.Tiny.UI.Controls