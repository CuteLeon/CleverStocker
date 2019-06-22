using NLog;
using System;

namespace CleverStocker.Utils
{
    /// <summary>
    /// 日志助手
    /// </summary>
    /// <typeparam name="TSource">日志来源类型</typeparam>
    /// <remarks>自动为每个泛型类型创建不同的单实例懒加载类型</remarks>
    public static class LogHelper<TSource>
    {
        /// <summary>
        /// 日志记录器
        /// </summary>
        private readonly static ILogger Logger = null;

        /// <summary>
        /// 静态构造函数
        /// </summary>
        static LogHelper()
        {
            Logger = new LogFactory().GetLogger(typeof(TSource).FullName);
        }

        #region 日志开关

        /// <summary>
        /// Trace 日志开关
        /// </summary>
        public static bool IsTraceEnabled
        {
            get => Logger.IsTraceEnabled;
        }

        /// <summary>
        /// Debug 日志开关
        /// </summary>
        public static bool IsDebugEnabled
        {
            get => Logger.IsDebugEnabled;
        }

        /// <summary>
        /// Info 日志开关
        /// </summary>
        public static bool IsInfoEnabled
        {
            get => Logger.IsInfoEnabled;
        }

        /// <summary>
        /// Warn 日志开关
        /// </summary>
        public static bool IsWarnEnabled
        {
            get => Logger.IsWarnEnabled;
        }

        /// <summary>
        /// Error 日志开关
        /// </summary>
        public static bool IsErrorEnabled
        {
            get => Logger.IsErrorEnabled;
        }

        /// <summary>
        /// Fatal 日志开关
        /// </summary>
        public static bool IsFatalEnabled
        {
            get => Logger.IsFatalEnabled;
        }
        #endregion

        #region Trace

        /// <summary>
        /// Trace 日志
        /// </summary>
        /// <param name="value"></param>
        public static void Trace(object value)
            => Logger.Trace(value);

        /// <summary>
        /// Trace 日志
        /// </summary>
        /// <param name="message"></param>
        public static void Trace(string message)
            => Logger.Trace(message);

        /// <summary>
        /// Trace 日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="values"></param>
        public static void Trace(string message, params object[] values)
            => Logger.Trace(string.Format(message, values));

        /// <summary>
        /// Trace 异常日志
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="message"></param>
        public static void TraceException(Exception ex, string message)
            => Logger.Trace(ex, message);
        #endregion

        #region Debug

        /// <summary>
        /// Debug 日志
        /// </summary>
        /// <param name="value"></param>
        public static void Debug(object value)
            => Logger.Debug(value);

        /// <summary>
        /// Debug 日志
        /// </summary>
        /// <param name="message"></param>
        public static void Debug(string message)
            => Logger.Debug(message);

        /// <summary>
        /// Debug 日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="values"></param>
        public static void Debug(string message, params object[] values)
            => Logger.Debug(string.Format(message, values));

        /// <summary>
        /// Debug 异常日志
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="message"></param>
        public static void DebugException(Exception ex, string message)
            => Logger.Debug(ex, message);
        #endregion

        #region Info

        /// <summary>
        /// Info 日志
        /// </summary>
        /// <param name="value"></param>
        public static void Info(object value)
            => Logger.Info(value);

        /// <summary>
        /// Info 日志
        /// </summary>
        /// <param name="message"></param>
        public static void Info(string message)
            => Logger.Info(message);

        /// <summary>
        /// Info 日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="values"></param>
        public static void Info(string message, params object[] values)
            => Logger.Info(string.Format(message, values));

        /// <summary>
        /// Info 异常日志
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="message"></param>
        public static void InfoException(Exception ex, string message)
            => Logger.Info(ex, message);
        #endregion

        #region Warn

        /// <summary>
        /// Warn 日志
        /// </summary>
        /// <param name="value"></param>
        public static void Warn(object value)
            => Logger.Warn(value);

        /// <summary>
        /// Warn 日志
        /// </summary>
        /// <param name="message"></param>
        public static void Warn(string message)
            => Logger.Warn(message);

        /// <summary>
        /// Warn 日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="values"></param>
        public static void Warn(string message, params object[] values)
            => Logger.Warn(string.Format(message, values));

        /// <summary>
        /// Warn 异常日志
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="message"></param>
        public static void WarnException(Exception ex, string message)
            => Logger.Warn(ex, message);
        #endregion

        #region Error

        /// <summary>
        /// Error 日志
        /// </summary>
        /// <param name="value"></param>
        public static void Error(object value)
            => Logger.Error(value);

        /// <summary>
        /// Error 日志
        /// </summary>
        /// <param name="message"></param>
        public static void Error(string message)
            => Logger.Error(message);

        /// <summary>
        /// Error 日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="values"></param>
        public static void Error(string message, params object[] values)
            => Logger.Error(string.Format(message, values));

        /// <summary>
        /// Error 异常日志
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="message"></param>
        public static void ErrorException(Exception ex, string message)
            => Logger.Error(ex, message);
        #endregion

        #region Fatal

        /// <summary>
        /// Fatal 日志
        /// </summary>
        /// <param name="value"></param>
        public static void Fatal(object value)
            => Logger.Fatal(value);

        /// <summary>
        /// Fatal 日志
        /// </summary>
        /// <param name="message"></param>
        public static void Fatal(string message)
            => Logger.Fatal(message);

        /// <summary>
        /// Fatal 日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="values"></param>
        public static void Fatal(string message, params object[] values)
            => Logger.Fatal(string.Format(message, values));

        /// <summary>
        /// Fatal 异常日志
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="message"></param>
        public static void FatalException(Exception ex, string message)
            => Logger.Fatal(ex, message);
        #endregion
    }
}
