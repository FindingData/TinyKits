using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Tiny.ProjectBuilder
{
    /// <summary>
    /// 数据库类型|type of database
    /// </summary>
    public enum DBType
    {
        /// <summary>
        /// SqlServer 2005、2008 universal low versions
        /// </summary>
        SqlServer = 0,

        /// <summary>
        /// SqlServer 2012 High version
        /// </summary>
        SqlServer2012 = 1,

        /// <summary>
        /// MySQL
        /// </summary>
        MySQL = 2,

        /// <summary>
        /// SQLite
        /// </summary>
        SQLite = 3,

        /// <summary>
        /// PostgreSQL
        /// </summary>
        Postgres = 4,

        /// <summary>
        /// Oracle
        /// </summary>
        Oracle = 5
    }
}
