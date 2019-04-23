///////////////////////////////////////////////////////////
//  Rate.cs
//  Implementation of the Class Rate
//  Generated by Enterprise Architect
//  Created on:      22-4月-2019 16:32:12
//  Original author: drago
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using FD.Tiny.FormBuilder;
namespace FD.Tiny.FormBuilder {
	public class Rate : BaseControl {

        public Rate()
        {
            this.control_type = ControlType.rate;
        }

        /// <summary>
        /// 是否可半选
        /// </summary>
		public bool allow_half{
			get;
			set;
		} 

        /// <summary>
        /// 最大值
        /// </summary>
		public int max{
			get;
			set;
		}

	}//end Rate

}//end namespace FD.Tiny.FormBuilder