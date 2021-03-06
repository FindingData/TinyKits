///////////////////////////////////////////////////////////
//  Data.cs
//  Implementation of the Class Data
//  Generated by Enterprise Architect
//  Created on:      24-4月-2019 18:12:29
//  Original author: drago
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



namespace FD.Tiny.FormBuilder {
	public class Data {

		/// <summary>
		/// 数据id
		/// </summary>
		public int data_id{
			get;
			set;
		}

		/// <summary>
		/// 数据名称
		/// </summary>
		public string data_name{
			get;
			set;
		}

		/// <summary>
		/// 同义数据Id
		/// </summary>
		public int syn_data_id{
			get;
			set;
		}

		/// <summary>
		/// 分组名称
		/// </summary>
		public string group_name{
			get;
			set;
		}

	}//end Data

}//end namespace Data