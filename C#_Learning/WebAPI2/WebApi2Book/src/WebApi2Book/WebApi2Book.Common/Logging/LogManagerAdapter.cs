namespace WebApi2Book.Common.Logging
{
    using System;
    using log4net;

    public class LogManagerAdapter : ILogManager
    {
        public ILog GetLog(Type typeAssociatedWithRequestedLog)
        {
            var log = LogManager.GetLogger(typeAssociatedWithRequestedLog);

            return log;
        }
    }
}
