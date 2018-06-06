///////////////////////////////////////////////////////////
//  OracleProvider.cs
//  Implementation of the Class OracleProvider
//  Generated by Enterprise Architect
//  Created on:      06-6��-2018 9:17:45
//  Original author: drago
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using FD.Tiny.DataAccess;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using FD.Tiny.Common.Utility.Validates;
using FD.Tiny.Common.Utility.Converts;

namespace FD.Tiny.DataAccess {
    public class OracleProvider : AdoProvider {
        private string _connectionString = "";

        public override string ConnectionString
        {
            get { return _connectionString; }
        }


        public OracleProvider(string connectionString){
            if (string.IsNullOrEmpty(connectionString))
                Check.Exception(true,string.Format(ErrorMessage.CanNotNull,"connectionString"));
            this._connectionString = connectionString;
        }

		/// 
		/// <param name="sql"></param>
		/// <param name="parameters"></param>
		public override IDbCommand GetCommand(string sql, SugarParameter[] parameters){
            OracleCommand sqlCommand = new OracleCommand(sql, (OracleConnection)this.Connection);
            sqlCommand.BindByName = true;
            sqlCommand.CommandType = this.CommandType;
            sqlCommand.CommandTimeout = this.CommandTimeOut;
            if (this.Transaction != null) {
                sqlCommand.Transaction = (OracleTransaction)this.Transaction;
            }
            if (parameters.HasValue())
            {
                IDataParameter[] ipars = ToIDbDataParameter(parameters);
                sqlCommand.Parameters.AddRange((OracleParameter[])ipars);
            }
            CheckConnection();
			return sqlCommand;
		}

		/// 
		/// <param name="adapter"></param>
		/// <param name="command"></param>
		public override void SetCommandToAdapter(IDataAdapter adapter, IDbCommand command){
            ((OracleDataAdapter)adapter).SelectCommand = (OracleCommand)command;
		}

		public override IDataAdapter GetAdapter(){
            return new OracleDataAdapter();
		}

		public override IDbConnection Connection{
            get
            {
                try
                {
                    if(base._DbConnection == null)
                    {
                        base._DbConnection = new OracleConnection(ConnectionString);
                    }
                }
                catch (Exception ex)
                {
                    Check.Exception(true, ErrorMessage.ConnnectionOpen, ex.Message);
                }
                return base._DbConnection;
            }
            set
            {
                this._DbConnection = value;
            }
		}

    
       

        public override IDataParameter[] ToIDbDataParameter(params SugarParameter[] parameters)
        {
            if (!parameters.HasValue()) return null;
            OracleParameter[] result = new OracleParameter[parameters.Length];
            int index = 0;
            foreach (var parameter in parameters)
            {
                if (parameter.Value == null)
                {
                    parameter.Value = DBNull.Value;
                }
                var sqlParameter = new OracleParameter();
                sqlParameter.Size = parameter.Size == -1 ? 0 : parameter.Size;
                sqlParameter.ParameterName = parameter.ParameterName;
                if (this.CommandType == CommandType.StoredProcedure)
                {
                    sqlParameter.ParameterName = sqlParameter.ParameterName.TrimStart(':');
                }
                if (parameter.IsRefCursor)
                {
                    sqlParameter.OracleDbType = OracleDbType.RefCursor;
                }
                if (sqlParameter.DbType== DbType.Guid)
                {
                    sqlParameter.DbType = DbType.String;
                    sqlParameter.Value = sqlParameter.Value.ObjToString();
                }
                else if (parameter.DbType==  DbType.Boolean)
                {
                    sqlParameter.DbType = DbType.Int16;
                    if (parameter.Value == DBNull.Value)
                    {
                        parameter.Value = 0;
                    }
                    else
                    {
                        sqlParameter.Value = (bool)parameter.Value ? 1 : 0;
                    }
                }
                else
                {
                    if (parameter.Value!=null && parameter.Value.GetType()== UtilConstants.GuidType)
                    {
                        parameter.Value = parameter.Value.ToString();
                    }
                    sqlParameter.Value = parameter.Value;
                }
                if (parameter.Direction != 0)
                    sqlParameter.Direction = parameter.Direction;
                result[index] = sqlParameter;
                if (sqlParameter.Direction.IsIn(ParameterDirection.Output,ParameterDirection.InputOutput,ParameterDirection.ReturnValue))
                {
                    if (this.OutputParameters==null)
                    {
                        this.OutputParameters = new List<IDataParameter>();
                    }
                    this.OutputParameters.RemoveAll(it => it.ParameterName == sqlParameter.ParameterName);
                    this.OutputParameters.Add(sqlParameter);
                }
                ++index;
            }
            return result;
        }

    }//end OracleProvider

}//end namespace FD.Tiny.DataAccess