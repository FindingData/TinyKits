using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Tiny.ProjectBuilder
{
    /// <summary>
    /// database config
    /// </summary>
    public class DBSetting
    {
        /// <summary>
        /// 数据库链接串|Connection string 
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// 数据库类型|type of database
        /// </summary>
        public DBType DBType { get; set; }
    }
}
