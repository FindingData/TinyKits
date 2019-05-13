///////////////////////////////////////////////////////////
//  Slider.cs
//  Implementation of the Class Slider
//  Generated by Enterprise Architect
//  Created on:      22-4��-2019 15:50:13
//  Original author: drago
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using FD.Tiny.FormBuilder;
namespace FD.Tiny.FormBuilder {
	public class Slider : BaseControl {

		public Slider(){

			this.control_type = ControlType.slider;
		}

        /// <summary>
        /// ��Сֵ
        /// </summary>
		public int min{
			get; set;
		} = 0;

        /// <summary>
        /// ���ֵ
        /// </summary>
		public int max{
			get; set;
		} = 100;

        /// <summary>
        /// ����
        /// </summary>
		public int step{
			get; set;
		} = 1;

        /// <summary>
        /// ��ʽ��
        /// </summary>
		public string format_tooltip{
			get;
			set;
		}

        /// <summary>
        /// �Ƿ���ʾ�ϵ�
        /// </summary>
        public bool show_stops
        {
            get; set;
        } = true;

        /// <summary>
        /// �Ƿ���ʾ��ʾ
        /// </summary>
		public bool show_tooltip{
			get; set;
		} = true;

	}//end Slider

}//end namespace FD.Tiny.FormBuilder