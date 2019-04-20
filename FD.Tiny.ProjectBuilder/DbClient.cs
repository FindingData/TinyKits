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

        protected DBSetting CurrentDbSetting;      

        public DbClient(DBSetting dbSetting)
        {
            CurrentDbSetting = dbSetting;
            ConnectionFactory.ConfigRegist(dbSetting);         
        }

        public virtual IDbSchema DbSchema {
            get
            {
                if (this._DbSchem == null)
                {
                    var result = InstanceFactory.GetDbSchema(CurrentDbSetting);
                    this._DbSchem = result;
                    result.Context = this;
                    return result;
                }
                return this._DbSchem;
            }
        }

        public virtual IDbBind DbBind
        {
            get
            {
                IDbBind dbBind = InstanceFactory.GetDbBind(CurrentDbSetting);
                return dbBind;
            }
        }

        public virtual IDbConnection DbConnection
        {
            get
            {
                return ConnectionFactory.GetDbConnection();
            }
        } 

    }
}
