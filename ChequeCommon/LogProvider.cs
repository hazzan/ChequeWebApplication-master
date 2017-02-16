using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using log4net.Core;

namespace ChequeCommon
{
    public enum LogLevel
    {
        /// <summary>
        /// Debug log level
        /// </summary>
        Debug,

        /// <summary>
        /// Error log level
        /// </summary>
        Error
    }
    [DebuggerNonUserCode]
    public static class LogProvider
    {
        /// <summary>
        /// Keeps a list of created logger objects
        /// </summary>
        private static Hashtable loggers = new Hashtable();

        /// <summary>
        /// customized logging format
        /// </summary>
        private const string customLogFormat = "{0} | User Id: {1}\n";

        static LogProvider()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        /// <summary>
        /// This will Log the provided logging information to a log file. 
        /// </summary>
        /// <param name="callerType"> Used to indicate caller type.</param>
        /// <param name="logLevel"> Used to indicate log level.</param>
        /// <param name="message"> Used to pass the logging message.</param>
        public static void Log(Type callerType, LogLevel logLevel, string massage)
        {
            if (null == callerType)
            {
                throw new ArgumentNullException();
            }

            //Get the correct logger instance
            Log4NetLogger logger = GetLogger(logLevel.ToString()); 
        }
        /// <summary>
        /// This will Log the provided logging information to a log file. 
        /// </summary>
        /// <param name="callerType"> Used to indicate caller type.</param>
        /// <param name="logLevel"> Used to indicate log level.</param>
        /// <param name="message"> Used to pass the logging message.</param>
        /// <param name="ex"> Used to pass the exception object.</param>
        public static void Log(Type callerType, LogLevel logLevel, string message, Exception ex)
        {
            if (null == callerType)
            {
                throw new ArgumentNullException(LogingResource.CallerTypeString, LogingResource.CallerTypeNotAllowedString);
            }

            //Get the correct logger instance
            Log4NetLogger logger = GetLogger(logLevel.ToString());

            //Log the logging information provided
            logger.Log(callerType, ConvertLogLevel(logLevel), message, ex);
        }

        /// <summary>
        /// This will Log the provided logging information to a log file. 
        /// </summary>
        /// <param name="callerType"> Used to indicate caller type.</param>
        /// <param name="logLevel"> Used to indicate log level.</param>
        /// <param name="message"> Used to pass the logging message.</param>
        public static void Log(Type callerType, LogLevel logLevel, string message, string userId)
        {
            if (null == callerType)
            {
                throw new ArgumentNullException(LogingResource.CallerTypeString, LogingResource.CallerTypeNotAllowedString);
            }

            //Get the correct logger instance
            Log4NetLogger logger = GetLogger(logLevel.ToString());

            //Log the logging information provided
            logger.Log(callerType, ConvertLogLevel(logLevel), string.Format(CultureInfo.InvariantCulture, customLogFormat, message, userId));

        }

        /// <summary>
        /// This will Log the provided logging information to a log file. 
        /// </summary>
        /// <param name="callerType"> Used to indicate caller type.</param>
        /// <param name="logLevel"> Used to indicate log level.</param>
        /// <param name="message"> Used to pass the logging message.</param>
        /// <param name="ex"> Used to pass the exception object.</param>
        public static void Log(Type callerType, LogLevel logLevel, string message, Exception ex, string userId)
        {
            if (null == callerType)
            {
                throw new ArgumentNullException(LogingResource.CallerTypeString, LogingResource.CallerTypeNotAllowedString);
            }

            //Get the correct logger instance
            Log4NetLogger logger = GetLogger(logLevel.ToString());

            //Log the logging information provided
            logger.Log(callerType, ConvertLogLevel(logLevel), string.Format(CultureInfo.InvariantCulture, customLogFormat, message, userId), ex);
        }

        private static Log4NetLogger GetLogger(string loggerName) 
        {
            Log4NetLogger returnLogger = null;
            if (!loggers.ContainsKey(loggerName))
            {
                lock (loggers)
                {
                    if (!loggers.ContainsKey(loggerName))
                    {
                        returnLogger = new Log4NetLogger(log4net.LogManager.GetLogger(loggerName));
                        loggers.Add(loggerName, returnLogger);
                    }
                }
            }

            returnLogger = (Log4NetLogger)loggers[loggerName];
            if (null == returnLogger)
            {
                throw new Exception();
            }

            return returnLogger;
        }

        private static log4net.Core.Level ConvertLogLevel(LogLevel level) 
        {
            Level returnLevel = null;
            switch (level)
            {
                case LogLevel.Debug:
                    returnLevel = Level.Debug;
                    break;
                case LogLevel.Error:
                    returnLevel = Level.Error;
                    break;
                default:
                    break;
            }

            return returnLevel;
        }

    }
}
