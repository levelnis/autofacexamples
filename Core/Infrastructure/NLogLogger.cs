namespace Levelnis.Learning.AutofacExamples.Core.Infrastructure
{
    using System;
    using NLog;

    public class NLogLogger : ILogger
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public void Trace(string message, params object[] format)
        {
            logger.Log(LogLevel.Trace, message, format);
        }

        public void Debug(string message, params object[] format)
        {
            logger.Log(LogLevel.Debug, message, format);
        }

        public void Info(string message, params object[] format)
        {
            logger.Log(LogLevel.Info, message, format);
        }

        public void Warn(string message, params object[] format)
        {
            logger.Log(LogLevel.Warn, message, format);
        }

        public void Error(string message, params object[] format)
        {
            logger.Log(LogLevel.Error, message, format);
        }

        public void ErrorException(Exception ex, string message, params object[] format)
        {
            logger.Log(LogLevel.Error, ex, message, format);
        }

        public void Fatal(string message, params object[] format)
        {
            logger.Log(LogLevel.Fatal, message, format);
        }
    }
}