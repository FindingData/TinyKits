///////////////////////////////////////////////////////////
//  ApiDataSource.cs
//  Implementation of the Class ApiDataSource
//  Generated by Enterprise Architect
//  Created on:      27-3月-2019 15:36:58
//  Original author: drago
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using System.Collections.Generic;
using FD.Tiny.FormBuilder;
namespace FD.Tiny.FormBuilder {
	/// <summary>
	/// 接口数据源
	/// </summary>
	public class ApiDataSource : DataSource {

		public ApiDataSource(){

			this.data_source_type = DataSourceType.DataApi;
		}

		/// <summary>
		/// 接口名称
		/// </summary>
		public string api_name{
			get;  set;
		}

		public int api_id{
			get;
						set;
		}

		/// <summary>
		/// 参数列表
		/// </summary>
		public Dictionary<string,string> request_parameter_map{
			get;  set;
		}

		public Dictionary<string,string> response_parameter_map{
			get;
			set;
		}

		public Option map_option{
			get;
			set;
		}

	}//end ApiDataSource

}//end namespace FD.Tiny.FormBuilder