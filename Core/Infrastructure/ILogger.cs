namespace Levelnis.Learning.AutofacExamples.Core.Infrastructure
{
    using System;

    public interface ILogger
    {
        void Trace(string message, params object[] format);

        void Debug(string message, params object[] format);

        void Info(string message, params object[] format);

        void Warn(string message, params object[] format);

        void Error(string message, params object[] format);

        void ErrorException(Exception ex, string message, params object[] format);

        void Fatal(string message, params object[] format);
    }
}