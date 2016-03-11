using System.Web.Http;

namespace WebApi2Book.Web.Api
{
    using WebApi2Book.Common;
    using WebApi2Book.Common.Logging;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        protected void Application_Error()
        {
            var exception = Server.GetLastError();
            if (exception != null)
            {
                var log = WebContainerManager.Get<ILogManager>().GetLog(typeof (WebApiApplication));
                log.Error("Unhandled exception: ", exception);
            }
        }
    }
}
