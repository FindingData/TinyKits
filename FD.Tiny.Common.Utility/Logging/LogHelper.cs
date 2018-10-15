using Common.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FD.Tiny.Common.Utility.Logging
{
    public class LogHelper
    {
        /// <summary>
        /// 加载日志配置信息
        /// </summary>
        //public static void Configure()
        //{
        //    log4net.Config.XmlConfigurator.Configure();
        //}

        /// <summary>
        /// 加载日志配置信息
        /// </summary>
        //public static void Configure(System.IO.Stream config)
        //{
        //    log4net.Config.XmlConfigurator.Configure(config);
        //}

        static string GetCaller()
        {
            // get call stack
            //StackTrace stackTrace = new StackTrace();
            //MethodBase mb = stackTrace.GetFrame(1).GetMethod();

            MethodBase mb = new StackFrame(2).GetMethod();
            Type t = mb.DeclaringType;
            return String.Format("{0}.{1}", t.FullName, mb.Name);
        }


        public static void Default(string message)
        {
            ILog Log = LogManager.GetLogger("");
            string str = String.Format("{0} : {1}", GetCaller(), message);
            Log.Info(str);
        }

        /// <summary>
        /// 记录一条错误日志
        /// </summary>
        /// <param name="message"></param>
        public static void Error(string message)
        {
            ILog Log = LogManager.GetLogger("logerror");
            Log.Error(message);
        }

        /// <summary>
        /// 记录一条错误日志
        /// </summary>
        /// <param name="ex"></param>
        public static void Error(Exception ex)
        {
            ILog Log = LogManager.GetLogger("logerror");
            Log.Error(ex.Message, ex);
        }

        /// <summary>
        /// 记录一条错误日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public static void Error(string message, Exception ex)
        {
            ILog Log = LogManager.GetLogger("logerror");
            Log.Error(message, ex);
        }

        /// <summary>
        /// 记录一条信息日志
        /// </summary>
        /// <param name="message"></param>
        public static void Info(string message)
        {
            ILog Log = LogManager.GetLogger("loginfo");
            Log.Info(message);
        }

        /// <summary>
        /// 记录一条安全信息日志
        /// </summary>
        /// <param name="message"></param>
        public static void SecurityInfo(string message)
        {
            ILog Log = LogManager.GetLogger("logsecurity");
            Log.Info(message);
        }

        public static void TaskInfo(string message)
        {
            ILog Log = LogManager.GetLogger("logtask");
            Log.Info(message);
        }

        public static void PerformanceInfo(string message)
        {
            ILog Log = LogManager.GetLogger("logperformance");
            Log.Info(message);
        }

        public static void SurveyInfo(string message)
        {
            ILog Log = LogManager.GetLogger("logsurveyinfo");
            Log.Info(message);
        }

        /*
        public static void PageAccessInfo(string userId, string ip, string url, string userAgent)
        {
            if (ConfigSetting.EnablePageAccessLog)
            {
                ILog Log = LogManager.GetLogger("logpage");
                string message = string.Format("{0:yyyy-MM-dd HH:mm:ss},{1},{2},{3},{4}", DateTime.Now, userId, ip, userAgent, url);
                Log.Info(message);
            }
        }

        public static void PerformanceInfo(string userId, string ip, string url, double ms)
        {
            if (ConfigSetting.EnablePerformanceLog)
            {
                ILog Log = LogManager.GetLogger("logperformance");
                string message = string.Format("{0:yyyy-MM-dd HH:mm:ss},{1},{2},{3},{4}", DateTime.Now, userId, ip, ms, url);
                Log.Info(message);
            }
        }
        */
    }
}
