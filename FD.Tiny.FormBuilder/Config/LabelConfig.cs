///////////////////////////////////////////////////////////
//  LabelConfig.cs
//  Implementation of the Class LabelConfig
//  Generated by Enterprise Architect
//  Created on:      27-3月-2019 10:20:06
//  Original author: drago
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using FD.Tiny.FormBuilder;
namespace FD.Tiny.FormBuilder {
	/// <summary>
	/// 表单变量
	/// </summary>
	public class LabelConfig {

		/// <summary>
		/// 数据源配置
		/// </summary>
		public DataSource data_source{
			get;  set;
		}

		/// <summary>
		/// 关联配置
		/// </summary>
		public List<Relate> relate_list{
			get;  set;
		}

		public List<Condition> condition_list{
			get;
			set;
		}

		/// <summary>
		/// 数据库配置
		/// </summary>
		public DatabaseConfig database_config{
			get;
						set;
		}

		/// <summary>
		/// 格式化配置
		/// </summary>
		public BaseFormat format_config{
			get;  set;
		}

		public ControlConfig control_config{
			get;
			set;
		}

		public List<BaseValidator> validator_list{
			get;
			set;
		}

		public bool is_parameter{
			get;
			set;
		}

		public ValueMethod value_method{
			get;
			set;
		}

	}//end LabelConfig

}//end namespace FD.Tiny.FormBuilder