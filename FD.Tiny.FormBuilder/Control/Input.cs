///////////////////////////////////////////////////////////
//  Input.cs
//  Implementation of the Class Input
//  Generated by Enterprise Architect
//  Created on:      22-4��-2019 15:50:03
//  Original author: drago
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using FD.Tiny.FormBuilder;
namespace FD.Tiny.FormBuilder {
	public class Input : BaseControl {

		public Input(){
			this.control_type = ControlType.input_base;
            this.clearable = true;
            this.@readonly = false;
		}

		 

	}//end Input

}//end namespace FD.Tiny.FormBuilder