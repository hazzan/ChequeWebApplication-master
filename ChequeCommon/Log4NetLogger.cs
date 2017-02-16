using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using log4net.Core;

namespace ChequeCommon
{
    /// <summary>
    /// Implements logging mechanism using Log4Net
    /// </summary>
    [DebuggerNonUserCode]
    internal class Log4NetLogger
    {
        /// <summary>
        /// Keep the logger instance
        /// </summary>
        private log4net.ILog logger;

        public Log4NetLogger(log4net.ILog logInfo)
        {
            this.logger = logInfo;
        }

        /// <summary>
        /// This will Log the provided logging information to a log file. 
        /// </summary>
        /// <param name="callerType"> Used to indicate caller type.</param>
        /// <param name="logLevel"> Used to indicate log level.</param>
        /// <param name="message"> Used to pass the logging message.</param>
        internal void Log(Type callerType, Level logLevel, string message)
        {
            this.logger.Logger.Log(callerType, logLevel, message, null);
        }

        /// <summary>
        /// This will Log the provided logging information to a log file. 
        /// </summary>
        /// <param name="callerType"> Used to indicate caller type.</param>
        /// <param name="logLevel"> Used to indicate log level.</param>
        /// <param name="message"> Used to pass the logging message.</param>
        /// <param name="ex"> Used to pass the exception object.</param>
        internal void Log(Type callerType, Level logLevel, string message, Exception ex)
        {
            this.logger.Logger.Log(callerType, logLevel, message, ex);
        }
    }
}
