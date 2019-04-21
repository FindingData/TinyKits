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
