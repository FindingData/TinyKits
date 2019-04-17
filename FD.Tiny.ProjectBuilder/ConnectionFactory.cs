using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Tiny.ProjectBuilder
{
    public class ConnectionFactory
    {
        private static ConcurrentDictionary<string, DBSetting> DBSettingDic;

        public const string DefaultAliase = "base";


        /// <summary>
        /// 注册链接|Register database links
        /// </summary>
        /// <param name="strConn">connection string</param>
        /// <param name="dBType">type of database</param>
        /// <param name="dbAliase">Multiple databases can be injected depending on the key</param>
        public static void ConfigRegist(string strConn, DBType dBType = DBType.Oracle, string dbAliase = DefaultAliase)
        {
            var dbSetting = new DBSetting() { ConnectionString = strConn, DBType = dBType };
            ConfigRegist(dbSetting, dbAliase);
        }

        /// <summary>
        /// 注册链接|Register database links
        /// </summary>
        /// <param name="db">connection model</param>
        /// <param name="dbAliase">Multiple databases can be injected depending on the key</param>
        public static void ConfigRegist(DBSetting db, string dbAliase = DefaultAliase)
        {
            if (DBSettingDic == null)
            {
                DBSettingDic = new ConcurrentDictionary<string, DBSetting>();
            }
            if (string.IsNullOrEmpty(dbAliase))
            {
                dbAliase = DefaultAliase;
            }
            if (DBSettingDic.ContainsKey(dbAliase))
            {
                throw new Exception("The same key already exists:" + dbAliase);
            }
            DBSettingDic[dbAliase] = db;
        }


        public static IDbConnection GetDbConnection(string dbAliase = DefaultAliase)
        {
            try
            {
                if (string.IsNullOrEmpty(dbAliase))
                {
                    dbAliase = DefaultAliase;
                }
                DBSetting dbSetting;
                if (!DBSettingDic.TryGetValue(dbAliase,out dbSetting))
                {
                    throw new Exception("The key doesn't exist:" + dbAliase);
                }
                var conn = dbSetting.ConnectionString;
                switch (dbSetting.DBType)
                {
                    case DBType.SqlServer:
                        return new SqlConnection(conn);
                    case DBType.Oracle:
                        return new OracleConnection(conn);                   
                }
                throw new Exception("Unregistered database link, please register by \"ConnectionBuilder.ConfigRegist\"");

            }
            catch (Exception ex)
            {
                throw new Exception("连接数据库过程中发生错误，检查服务器是否正常连接字符串是否正确", ex);
            }
        }

        /// <summary>
        /// Get DB Option
        /// </summary>
        /// <param name="dbAliase">DB alias</param>
        /// <returns></returns>
        public static DBSetting GetDBSetting(string dbAliase = DefaultAliase)
        {
            if (string.IsNullOrEmpty(dbAliase))
                dbAliase = DefaultAliase;
            DBSetting dBSetting;
            if (!DBSettingDic.TryGetValue(dbAliase, out dBSetting))
            {
                throw new Exception("The key doesn't exist:" + dbAliase);
            }
            return dBSetting;
        }    
    }
}
