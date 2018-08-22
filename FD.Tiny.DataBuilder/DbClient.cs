///////////////////////////////////////////////////////////
//  DataBuilderClient.cs
//  Implementation of the Class DataBuilderClient
//  Generated by Enterprise Architect
//  Created on:      14-6月-2018 15:17:30
//  Original author: drago
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using FD.Tiny.DataAccess;
using AutoMapper;
using AutoMapper.Data;

namespace FD.Tiny.DataBuilder {
	public class DbClient:IDisposable {

        public ConnectionConfig CurrentConnectionConfig { get; set; }

        protected IAdo _Ado;

        protected IDbMaintenance _DbMaintenance;
              

        public DbClient(ConnectionConfig config)
        {
            this.CurrentConnectionConfig = config;
            switch (config.DbType)
            {
                case DBType.Oracle:
                    DependencyManagement.TryOracle(this.CurrentConnectionConfig.ConnectionString);
                    break;
                case DBType.SqlServer:
                    Check.ThrowNotSupportedException("暂不支持SqlServer数据库");
                    break;
                default:
                    Check.ThrowNotSupportedException("暂不支持SqlServer数据库");
                    break;
            }
        }

        public virtual IAdo Ado
        {
            get
            {
                if (_Ado == null)
                {
                    var result = InstanceFactory.GetAdo(this.CurrentConnectionConfig);
                    this._Ado = result;
                    return result;
                }
                return _Ado;
            }
        }

        public virtual IDbMaintenance DbMaintenance
        {
            get
            {
                if (this._DbMaintenance==null)
                {
                    var result = InstanceFactory.GetDbMaintenance(this.CurrentConnectionConfig);
                    this._DbMaintenance = result;
                    result.Context = this;
                    return result;
                }
                return this._DbMaintenance;
            }
        }


        public virtual void Open()
        {
            if (this._Ado != null)
            {
                _Ado.Open();
            }
        }

        public virtual void Close()
        {
            if (this._Ado != null)
            {
                    _Ado.Close();
            }
        }

        public virtual void Dispose()
        {
            if (this._Ado!=null)
            {
                _Ado.Dispose();
            }
        }

        
    }//end DataBuilderClient

}//end namespace FD.Tiny.DataBuilder