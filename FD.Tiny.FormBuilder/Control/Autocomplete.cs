///////////////////////////////////////////////////////////
//  Autocomplete.cs
//  Implementation of the Class Autocomplete
//  Generated by Enterprise Architect
//  Created on:      22-4月-2019 15:49:51
//  Original author: drago
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using FD.Tiny.FormBuilder;
namespace FD.Tiny.FormBuilder {
	public class Autocomplete : BaseControl
    {

		public Autocomplete(){
            this.control_type = ControlType.input_autocomplete;
            this.@readonly = false;
            this.clearable = true;
		}

        /// <summary>
        /// 激活列出数据
        /// </summary>
		public bool trigger_on_focus{
			get; set;
		} = true;

        /// <summary>
        /// 未匹配时选中
        /// </summary>
		public bool select_when_unmatched{
			get; set;
		} = false;

	}//end Autocomplete

}//end namespace FD.Tiny.FormBuilder