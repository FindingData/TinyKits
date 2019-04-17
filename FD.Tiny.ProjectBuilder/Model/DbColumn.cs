///////////////////////////////////////////////////////////
//  DbColumn.cs
//  Implementation of the Class DbColumn
//  Generated by Enterprise Architect
//  Created on:      16-4月-2019 19:18:59
//  Original author: drago
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



namespace FD.Tiny.ProjectBuilder {
	public class DbColumn {

		public DbColumn(){

		}

		/// <summary>
		/// 名称
		/// </summary>
		public string name{
			get;  set;
		}

		/// <summary>
		/// 备注
		/// </summary>
		public string comment{
			get;  set;
		}

		/// <summary>
		/// 数据类型
		/// </summary>
		public string data_type{
			get;  set;
		}

		/// <summary>
		/// 长度
		/// </summary>
		public int length{
			get;  set;
		}

		/// <summary>
		/// 精度
		/// </summary>
		public int precision{
			get;  set;
		}

		/// <summary>
		/// 主键
		/// </summary>
		public bool is_primary{
			get;  set;
		}

		/// <summary>
		/// 是否可空
		/// </summary>
		public bool is_nullable{
			get;  set;
		}

		/// <summary>
		/// 默认值
		/// </summary>
		public string default_value{
			get;  set;
		}

		public int scale{
			get;
						set;
		}

	}//end DbColumn

}//end namespace FD.Tiny.ProjectBuilder