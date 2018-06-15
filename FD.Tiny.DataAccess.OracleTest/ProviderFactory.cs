using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Tiny.DataAccess.OracleTest
{
    public  class ProviderFactory
    {
        public static IAdo GetAdo(ConnectionConfig connectionConfig)
        {
            if (connectionConfig.DbType != DBType.Oracle)
            {
                Check.ThrowNotSupportedException("暂未支持其他数据库类型");
            }
            return new OracleProvider(connectionConfig.ConnectionString);
        }        
    }
}
