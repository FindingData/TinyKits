using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Tiny.ProjectBuilder
{
    public class DbClient
    {       
        protected IDbSchema _DbSchem;

        protected string Aliase;      

        public DbClient(DBSetting dbSetting,string aliase)
        {
            this.Aliase = aliase;
            ConnectionFactory.ConfigRegist(dbSetting, aliase);
        }

        public virtual IDbSchema DbSchema {
            get
            {
                if (this._DbSchem == null)
                {
                    var result = InstanceFactory.GetDbSchema(ConnectionFactory.GetDBSetting(Aliase));
                    this._DbSchem = result;
                    result.Context = this;
                    return result;
                }
                return this._DbSchem;
            }
        }

        public virtual IDbConnection DbConnection
        {
            get
            {
                return ConnectionFactory.GetDbConnection(Aliase);
            }
        } 

    }
}
