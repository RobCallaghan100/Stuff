﻿namespace WebApi2Book.Web.Common
{
    using System.Web.Http.ExceptionHandling;
    using log4net;
    using WebApi2Book.Common.Logging;

    public class SimpleExceptionLogger : ExceptionLogger
    {
        private readonly ILog _log;

        public SimpleExceptionLogger(ILogManager logManager)
        {
            _log = logManager.GetLog(typeof (SimpleExceptionLogger));
        }

        public override void Log(ExceptionLoggerContext context)
        {
            _log.Error("Unhandled exception", context.Exception);
        }
    }
}
