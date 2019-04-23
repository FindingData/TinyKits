///////////////////////////////////////////////////////////
//  TextArea.cs
//  Implementation of the Class TextArea
//  Generated by Enterprise Architect
//  Created on:      22-4月-2019 16:08:09
//  Original author: drago
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using FD.Tiny.FormBuilder;
namespace FD.Tiny.FormBuilder {
	/// <summary>
	/// 文本域
	/// </summary>
	public class TextArea : BaseControl {

        public TextArea()
        {
            this.control_type = ControlType.input_textarea;
            this.clearable = true;
            this.@readonly = false;
        }

        /// <summary>
        /// 内容高度
        /// </summary>
        public int? autosize
        {
            get;
            set;
        } 

        /// <summary>
        /// 缩放规则
        /// </summary>
        public string resize
        {
            get;
            set;
        } = "none";
         
	}//end TextArea

}//end namespace FD.Tiny.FormBuilder