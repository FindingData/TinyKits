using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Tiny.Common.Utility.Exceptions
{
    public class UtilExceptions : Exception
    {
        public UtilExceptions(string message)
            : base(message) { }
        
        private static string GetMessage(string message, string sql)
        {
            var reval = GetLineMessage("message         ", message) + GetLineMessage("ORM Sql", sql);
            return reval;
        }
        private static string GetLineMessage(string key, string value)
        {
            return string.Format("{0} ： '{1}' \r\n", key, value);
        }
    }
}
