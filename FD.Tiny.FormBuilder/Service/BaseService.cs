///////////////////////////////////////////////////////////
//  BaseService.cs
//  Implementation of the Class BaseService
//  Generated by Enterprise Architect
//  Created on:      29-9��-2018 15:36:34
//  Original author: drago
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



namespace FD.Tiny.FormBuilder {
	public class BaseService<T> where T : class
    {

        public IRepository<T> Repository { get; set; }

        public BaseService() { }

		/// 
		/// <param name="dbContext"></param>
		public BaseService(IRepository<T> repository){
            this.Repository = repository;
		}

	}//end BaseService

}//end namespace FD.Tiny.FormBuilder