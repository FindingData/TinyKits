using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Tiny.DataAccess.OracleTest
{
    public class DbTable : DbGeneral
    {

        public DbTable() { }

        public DbTable(string name)
        {
            this.name = name;
        }



        public List<DbColumn> columns
        {
            get; set;
        }
    }//end DbTable

    public class DbColumn : DbGeneral
    {

        /// <summary>
        /// 数据类型
        /// </summary>
        public string data_type { get; set; }
        /// <summary>
        /// 长度
        /// </summary>
        public int length { get; set; }
        /// <summary>
        /// 精度
        /// </summary>
        public int precision { get; set; }
        /// <summary>
        /// 主键
        /// </summary>
        public bool is_primary { get; set; }
        /// <summary>
        /// 是否可空
        /// </summary>
        public bool is_nullable { get; set; }
        /// <summary>
        /// 默认值
        /// </summary>
        public string default_value { get; set; }

        public DbColumn()
        {

        }

        public int scale
        {
            get;
            set;
        }

    }//end DbColumn

    public class DbGeneral
    {

        /// <summary>
        /// 名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 代码
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string comment { get; set; }

        public DbGeneral()
        {

        }

    }//end DbGeneral
}
