using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace CleverStocker.Utils
{

    /// <summary>
    /// 日志助手
    /// </summary>
    public static class LogHelper
    {
        static LogHelper()
        {
            // TODO: 泛型为目标类配置日志助手
            // LogFactory<string> logFactory = new LogFactory<string>();
            LogManager.GetCurrentClassLogger();
            // public static ILogger Logger = Log.LogManager.GetCurrentClassLogger();
        }

    }
}
