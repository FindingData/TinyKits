using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FD.Tiny.Common.Utility.Calc
{
    public class CalcStringExpression
    {
        /// <summary> 
           /// 由Microsoft.Eval对象计算表达式，需要引用Microsoft.JScript和Microsoft.Vsa名字空间。 
           /// </summary> 
           /// <param name="expression">表达式</param> 
           /// <returns></returns> 
        public static string CalcByJs(string expression)
        {
            try
            {
                Microsoft.JScript.Vsa.VsaEngine ve = Microsoft.JScript.Vsa.VsaEngine.CreateEngine();
                object returnValue = Microsoft.JScript.Eval.JScriptEvaluate((object)expression, ve);
                return returnValue.ToString();
            }
            catch
            {
                return string.Empty;
            }           
        }

        

        /// <summary>
        /// 条件正则
        /// </summary>
        /// <param name="str"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static string PatternString(string str, string pattern)
        {
            return Regex.Match(str, pattern).Value.Trim();
        }
       
       
    }
}
