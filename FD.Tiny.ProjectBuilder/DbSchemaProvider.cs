using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Tiny.ProjectBuilder
{
    public abstract class DbSchemaProvider : IDbSchema
    {

        public DbClient Context { get; set; }

        //private IDbConnection _dbConnection;
        /// <summary>
        /// IDbConnection
        /// </summary>
        //public IDbConnection DBConnection
        //{
        //    get
        //    {
        //        if (_dbConnection == null)
        //        {
        //            _dbConnection = ConnectionFactory.GetDbConnection(dbAliase);
        //        }
        //        if (_dbConnection.State == ConnectionState.Closed && _dbConnection.State != ConnectionState.Connecting)
        //        {
        //            _dbConnection.Open();
        //        }
        //        return _dbConnection;
        //    }
        //    private set { this._dbConnection = value; }
        //}

        //private string dbAliase;

        /// <summary>
        /// CurrentDB Setting
        /// </summary>
        //public DBSetting CurrentDBSetting => ConnectionFactory.GetDBSetting(dbAliase);



        public virtual List<DbColumn> GetColumnInfosByTableName(string tableName)
        {
            var sql = string.Format(this.GetColumnInfosByTableNameSql, tableName);
            return Context.DbConnection.Query<DbColumn>(sql).GroupBy(it => it.name).Select(it => it.First()).ToList();
        }

        public List<DbTable> GetTableInfoList()
        {
            return Context.DbConnection.Query<DbTable>(this.GetTableInfoListSql).ToList();
        }
       
        protected abstract string GetTableInfoListSql { get; }
        protected abstract string GetColumnInfosByTableNameSql { get; }
     
    }
}
