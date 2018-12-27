///////////////////////////////////////////////////////////
//  VariableConfig.cs
//  Implementation of the Class VariableConfig
//  Generated by Enterprise Architect
//  Created on:      25-12��-2018 10:55:23
//  Original author: drago
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using FD.Tiny.FormBuilder;
namespace FD.Tiny.FormBuilder {
	public class VariableConfig : LabelConfig {

		public bool is_parameter{
			get;
						set;
		}

		public ValueMethod value_method{
			get;
						set;
		}

	}//end VariableConfig

}//end namespace FD.Tiny.FormBuilder