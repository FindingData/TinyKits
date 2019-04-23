///////////////////////////////////////////////////////////
//  InputNumber.cs
//  Implementation of the Class InputNumber
//  Generated by Enterprise Architect
//  Created on:      22-4月-2019 16:35:00
//  Original author: drago
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using FD.Tiny.FormBuilder;
namespace FD.Tiny.FormBuilder {
	public class InputNumber : BaseControl {

		public InputNumber(){

			this.control_type = ControlType.input_number;
            this.@readonly = false;
		}

        /// <summary>
        /// 最大值
        /// </summary>
        public float min
        {
            get; set;
        } = 0;

        /// <summary>
        /// 最大值
        /// </summary>
        public float max
        {
            get; set;
        } = 100;

        /// <summary>
        /// 步长
        /// </summary>
        public float step
        {
            get; set;
        } = 1;

        /// <summary>
        /// 精度
        /// </summary>
        public int precision {
            get; set;
        } = 0;

        /// <summary>
        /// 按钮位置
        /// </summary>
        public string controls_position
        {
            get; set;
        } = "normal";

	}//end InputNumber

}//end namespace FD.Tiny.FormBuilder