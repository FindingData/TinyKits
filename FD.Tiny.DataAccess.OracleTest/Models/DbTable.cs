using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Tiny.DataAccess.OracleTest
{
    public class DbTable :DbGeneral
    {
         


    }//end DbTable

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
