///////////////////////////////////////////////////////////
//  Label.cs
//  Implementation of the Class Label
//  Generated by Enterprise Architect
//  Created on:      20-9月-2018 10:49:05
//  Original author: drago
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using FD.Tiny.FormBuilder;
using FD.Tiny.FormBuilder.Database;
namespace FD.Tiny.FormBuilder {
	/// <summary>
	/// 表单变量
	/// </summary>
	public class Label {

		/// <summary>
		/// 标签Id
		/// </summary>
		public int label_id{
			get;  set;
		}

		/// <summary>
		/// 表单Id
		/// </summary>
		public int form_id{
			get;  set;
		}

		/// <summary>
		/// 数据类型
		/// </summary>
		public DataType data_type{
			get;  set;
		}

		/// <summary>
		/// 标签中文名
		/// </summary>
		public string label_name_chs{
			get;  set;
		}

		/// <summary>
		/// 控件类型
		/// </summary>
		public string control_type{
			get;  set;
		}

		/// <summary>
		/// 默认值
		/// </summary>
		public string default_value{
			get;  set;
		}

		/// <summary>
		/// 标签排序
		/// </summary>
		public int label_sort{
			get;  set;
		}

		/// <summary>
		/// 分组名称
		/// </summary>
		public string group_name{
			get;  set;
		}

		/// <summary>
		/// 验证配置
		/// </summary>
		public ValidatorConfig validator_config{
			get;  set;
		}

		/// <summary>
		/// 条件配置
		/// </summary>
		public ConditionConfig condition_config{
			get;  set;
		}

		/// <summary>
		/// 数据源配置
		/// </summary>
		public DataSource data_source_config{
			get;  set;
		}

		/// <summary>
		/// 数据库配置
		/// </summary>
		public FD.Tiny.FormBuilder.Database.DatabaseConfig data_base_config{
			get;  set;
		}

		/// <summary>
		/// 关联配置
		/// </summary>
		public RelateConfig relate_config{
			get;  set;
		}

		/// <summary>
		/// 格式化配置
		/// </summary>
		public BaseFormat format_config{
			get;  set;
		}

	}//end Label

}//end namespace FD.Tiny.FormBuilder