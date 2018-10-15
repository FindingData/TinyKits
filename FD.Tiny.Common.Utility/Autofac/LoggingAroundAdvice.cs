using Castle.DynamicProxy;
using FD.Tiny.Common.Utility.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FD.Tiny.Common.Utility.Autofac
{
    /// <summary>
    /// 事务 拦截器
    /// </summary>
    /// <summary>
    /// 拦截器 需要实现 IInterceptor接口 Intercept方法
    /// </summary>
    public class LoggingAroundAdvice : IInterceptor
    {
        static long Id = 0;
        /// <summary>
        /// 拦截方法 打印被拦截的方法执行前的名称、参数和方法执行后的 返回结果
        /// </summary>
        /// <param name="invocation">包含被拦截方法的信息</param>
        public void Intercept(IInvocation invocation)
        {
            long nId = Interlocked.Increment(ref Id);

            Stopwatch sw = Stopwatch.StartNew();
            try
            {
                // 在被拦截的方法执行完毕后 继续执行
                invocation.Proceed();
                sw.Stop();

                LogHelper.Info(
                   String.Format("Invocation ID {0}: break \"{1}, {2}\", elapsed {3} milliseconds",
                   nId,
                   invocation.Method.Name,
                   invocation.TargetType.FullName,
                   sw.ElapsedMilliseconds.ToString("#,##0"))
                   );
            }
            catch (Exception ex)
            {
                if (sw.IsRunning)
                {
                    sw.Stop();
                }

                LogHelper.Error(
                    String.Format("Invocation ID {0}: break \"{1}, {2}\", Message:{3}",
                    nId,
                    invocation.Method.Name,
                    invocation.TargetType.FullName,
                    ex)
                    );
            }
            finally
            {
                if (sw.IsRunning)
                {
                    sw.Stop();
                }
            }
        }
    }
}
