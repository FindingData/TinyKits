///////////////////////////////////////////////////////////
//  ApiService.cs
//  Implementation of the Class ApiService
//  Generated by Enterprise Architect
//  Created on:      29-9��-2018 16:24:05
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
namespace FD.Tiny.FormBuilder {
	public class ApiService : BaseService<ApiPO> {

		/// 
		/// <param name="dbContext"></param>
		public ApiService(IRepository<ApiPO> repository): base(repository)
        {

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

		/// 
		/// <param name="apiId"></param>
		/// <param name="userId"></param>
		public void DelApi(int apiId, int userId){
            var api = Repository.FindSingle(r => r.API_ID == apiId);
            Repository.SoftDelete(api, userId);
        }

        ///         
        public List<Api> QueryApi()
        {
            var apis = Repository.Find().ToList();
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

	}//end ApiService

}//end namespace FD.Tiny.FormBuilder