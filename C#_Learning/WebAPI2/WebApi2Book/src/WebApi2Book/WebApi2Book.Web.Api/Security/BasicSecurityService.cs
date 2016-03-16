namespace WebApi2Book.Web.Api.Security
{
    using Data.Entities;
    using log4net;
    using NHibernate;
    using WebApi2Book.Common;
    using WebApi2Book.Common.Logging;

    public class BasicSecurityService : IBasicSecurityService
    {
        private readonly ILog _log;

        public BasicSecurityService(ILogManager logManager)
        {
            _log = logManager.GetLog(typeof(BasicSecurityService));
        }

        public virtual ISession Session
        {
            get { return WebContainerManager.Get<ISession>(); }
        }

        public bool SetPrincipal(string username, string password)
        {
//var user= GetUser
        }

        public virtual User GetUser(string userName)
        {
            userName = userName.ToLowerInvariant();

            return Session
        }
    }
}