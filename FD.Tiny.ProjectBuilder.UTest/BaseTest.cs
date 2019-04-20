using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Tiny.ProjectBuilder.UTest
{

    public class BaseTest
    {
        private TestContext testContextInstance;

        private string conn_str = ConfigurationManager.ConnectionStrings["BasDb"].ConnectionString;

        public DbClient GetInstance()
        {
            DbClient db = new DbClient(new DBSetting()
            {
                ConnectionString = conn_str,
                DBType = DBType.Oracle,
            });
            return db;
        }

        /// <summary>
        ///  Gets or sets the test context which provides
        ///  information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }
    }
}
