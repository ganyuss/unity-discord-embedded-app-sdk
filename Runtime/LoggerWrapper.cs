using System;
using JetBrains.Annotations;
using UnityEngine;
using Object = UnityEngine.Object;

namespace DiscordActivitySdk
{
    internal class LoggerWrapper : ILogger
    {
        private const string Prefix = "[DiscordSDK]  ";

        [NotNull] 
        private readonly ILogger InnerLogger;

        public LoggerWrapper([NotNull] ILogger innerLogger)
        {
            InnerLogger = innerLogger;
        }

        public void LogFormat(LogType logType, Object context, string format, params object[] args)
        {
            InnerLogger.LogFormat(logType, context, Prefix + format, args);
        }

        public void LogException(Exception exception, Object context)
        {
            InnerLogger.LogException(exception, context);
        }

        public bool IsLogTypeAllowed(LogType logType)
        {
            return InnerLogger.IsLogTypeAllowed(logType);
        }

        public void Log(LogType logType, object message)
        {
            if (message is string stringMessage)
                InnerLogger.Log(logType, Prefix + stringMessage);
            else
                InnerLogger.Log(logType, message);
        }

        public void Log(LogType logType, object message, Object context)
        {
            if (message is string stringMessage)
                InnerLogger.Log(logType, (object) (Prefix + stringMessage), context);
            else
                InnerLogger.Log(logType, message, context);
        }

        void ILogger.Log(LogType logType, string tag, object message)
        {
            throw new NotImplementedException();
        }

        void ILogger.Log(LogType logType, string tag, object message, Object context)
        {
            throw new NotImplementedException();
        }

        public void Log(object message)
        {
            if (message is string stringMessage)
                InnerLogger.Log(Prefix + stringMessage);
            else
                InnerLogger.Log(message);
        }

        void ILogger.Log(string tag, object message)
        {
            throw new NotImplementedException();
        }

        void ILogger.Log(string tag, object message, Object context)
        {
            throw new NotImplementedException();
        }

        void ILogger.LogWarning(string tag, object message)
        {
            throw new NotImplementedException();
        }

        void ILogger.LogWarning(string tag, object message, Object context)
        {
            throw new NotImplementedException();
        }

        void ILogger.LogError(string tag, object message)
        {
            throw new NotImplementedException();
        }

        void ILogger.LogError(string tag, object message, Object context)
        {
            throw new NotImplementedException();
        }

        public void LogFormat(LogType logType, string format, params object[] args)
        {
            InnerLogger.LogFormat(logType, Prefix + format, args);
        }

        public void LogException(Exception exception)
        {
            InnerLogger.LogException(exception);
        }

        public ILogHandler logHandler
        {
            get => InnerLogger.logHandler;
            set => InnerLogger.logHandler = value;
        }
        public bool logEnabled 
        {
            get => InnerLogger.logEnabled;
            set => InnerLogger.logEnabled = value;
        }
        public LogType filterLogType 
        {
            get => InnerLogger.filterLogType;
            set => InnerLogger.filterLogType = value;
        }
    }
}