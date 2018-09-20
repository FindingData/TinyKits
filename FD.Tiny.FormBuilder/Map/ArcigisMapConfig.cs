///////////////////////////////////////////////////////////
//  ArcigisMapConfig.cs
//  Implementation of the Class ArcgisMap
//  Generated by Enterprise Architect
//  Created on:      20-9月-2018 11:54:44
//  Original author: drago
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using FD.Tiny.FormBuilder;
namespace FD.Tiny.FormBuilder {
	/// <summary>
	/// arcGis地图
	/// </summary>
	public class ArcgisMap : Map {

		/// <summary>
		/// 基础图层服务
		/// </summary>
		public MapServer base_map_server{
			get;  set;
		}

		/// <summary>
		/// 网格服务
		/// </summary>
		public MapServer net_map_server{
			get;  set;
		}

		/// <summary>
		/// 定位服务
		/// </summary>
		public List<MapServer> location_map_server{
			get;  set;
		}

	}//end ArcgisMap

}//end namespace FD.Tiny.FormBuilder