using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Tiny.ProjectBuilder
{
    public interface IDbSchema
    {
        DbClient Context { get; set; }

        List<DbTable> GetTableInfoList();

        List<DbColumn> GetColumnInfosByTableName(string tableName);
    }
}
