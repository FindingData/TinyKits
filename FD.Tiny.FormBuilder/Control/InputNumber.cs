///////////////////////////////////////////////////////////
//  InputNumber.cs
//  Implementation of the Class InputNumber
//  Generated by Enterprise Architect
//  Created on:      22-4��-2019 16:35:00
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
        /// ���ֵ
        /// </summary>
        public float min
        {
            get; set;
        } = 0;

        /// <summary>
        /// ���ֵ
        /// </summary>
        public float max
        {
            get; set;
        } = 100;

        /// <summary>
        /// ����
        /// </summary>
        public float step
        {
            get; set;
        } = 1;

        /// <summary>
        /// ����
        /// </summary>
        public int precision {
            get; set;
        } = 0;

        /// <summary>
        /// ��ťλ��
        /// </summary>
        public string controls_position
        {
            get; set;
        } = "normal";

	}//end InputNumber

}//end namespace FD.Tiny.FormBuilder