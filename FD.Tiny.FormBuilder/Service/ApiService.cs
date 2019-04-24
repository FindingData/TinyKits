///////////////////////////////////////////////////////////
//  ApiService.cs
//  Implementation of the Class ApiService
//  Generated by Enterprise Architect
//  Created on:      29-9月-2018 16:24:05
//  Original author: drago
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using AutoMapper;
using System.Data.Entity;
using System.Linq;
using FD.Tiny.FormBuilder;
using FD.Tiny.Common.Utility.SqlParse;
using System.Text.RegularExpressions;

namespace FD.Tiny.FormBuilder {
	public class ApiService : BaseService<ApiPO> {
                

		/// 
		/// <param name="dbContext"></param>
		public ApiService(IRepository<ApiPO> repository): base(repository)
        {

		}


        public dynamic GetApiData(int apiId, List<ApiData> request)
        {
            var api = GetApi(apiId);
            Dictionary<string, object> dict = request.ToDictionary(r => r.parameter_name, r => (object)r.value);
            return Repository.DynamicFromSql(api.sql_content, dict);
        }

        public List<dynamic> GetApiListData(int apiId, List<ApiData> request)
        {
            var api = GetApi(apiId);
            Dictionary<string, object> dict = request.ToDictionary(r => r.parameter_name, r => (object)r.value);
            return Repository.DynamicListFromSql(api.sql_content, dict);
        }      

        /// 
        /// <param name="api"></param>
        /// <param name="userId"></param>
        public int AddApi(Api api, int userId)
        {
            var apiPo = Mapper.Map<Api, ApiPO>(api);
            Repository.Add(apiPo, userId);
            return (int)apiPo.API_ID;
        }

        /// 
        /// <param name="api"></param>
        /// <param name="userId"></param>
        public void SaveApi(Api api, int userId)
        {           
            var apiPo = Mapper.Map<Api, ApiPO>(api);
            Repository.Update(apiPo, userId);
        }

        public bool IsExistApi(string apiName)
        {
            var apiPo = Repository.FindSingle(r => r.API_NAME == apiName);
            return apiPo != null;
        }


        public string ParseSql(string sql)
        {
            return SqlParserUtil.GetParsedSql(sql);
        }
        
        public static List<ApiParameter> GetRequestParamsFromSql(string sql)
        {
            var parmList = new List<ApiParameter>();
            var segments = SqlParserUtil.GetParsedSqlSegmentList(sql).Find(s => s.SegmentRegExp.StartsWith("(where)")); //取第三段
            if (segments != null)
            {
                foreach (var piece in segments.BodyPieces)
                {
                    var match = Regex.Match(piece, @"(?<=:)[\w\W]+?(?=[\W])");
                    if (match.Success)
                    {
                        ApiParameter param = new ApiParameter()
                        {
                            data_type = DataType.String,
                            is_required = true,
                            parameter_name = match.Value,
                            parameter_name_chs = match.Value,
                        };
                        parmList.Add(param);
                    }
                }
            }
            return parmList;
            
        }


        public static List<ApiParameter> GetResponseParamsFromSql(string sql)
        {
            var parmList = new List<ApiParameter>();
            var segments = SqlParserUtil.GetParsedSqlSegmentList(sql).Find(s => s.SegmentRegExp.StartsWith("(select)")); //取第一段
            if (segments != null)
            {
                foreach (var piece in segments.BodyPieces)
                {
                    string[] keyValue = Regex.Split(piece, "\\.");
                    string parameterName = keyValue[0].Trim(',').Trim();
                    if (keyValue.Length == 2)
                    {
                        parameterName = keyValue[1].Trim(',').Trim();
                    }
                    ApiParameter param = new ApiParameter()
                    {
                        data_type = DataType.String,
                        is_required = true,
                        parameter_name = parameterName,
                        parameter_name_chs = parameterName,
                    };
                    parmList.Add(param);
                }
            }
            return parmList;
        }

		/// 
		/// <param name="apiId"></param>
		/// <param name="userId"></param>
		public void DelApi(int apiId, int userId){
            var api = Repository.FindSingle(r => r.API_ID == apiId);
            Repository.SoftDelete(api, userId);
        }

        ///         
        public List<Api> QueryApi(string name)
        {
            var apis = Repository.Find(a => string.IsNullOrEmpty(name) || a.API_NAME.Contains(name)).ToList();
            var list = Mapper.Map<List<ApiPO>, List<Api>>(apis);
            return list;
        }

        /// 
        /// <param name="apiId"></param>
        public Api GetApi(int apiId)
        {
            var apiPo = Repository.FindSingle(r => r.API_ID == apiId);
            var api = Mapper.Map<ApiPO, Api>(apiPo);
            return api;
        }

        public Api GetApi(string apiName)
        {
            var apiPo = Repository.FindSingle(r => r.API_NAME == apiName);
            var api = Mapper.Map<ApiPO, Api>(apiPo);
            return api;
        }

	}//end ApiService

}//end namespace FD.Tiny.FormBuilder