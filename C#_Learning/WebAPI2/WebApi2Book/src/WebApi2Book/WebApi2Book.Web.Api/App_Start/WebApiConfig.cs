using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.Routing;
using WebApi2Book.Common.Routing;
using WebApi2Book.Web.Common;

namespace WebApi2Book.Web.Api
{
    using System.Web.Http.Tracing;
    using WebApi2Book.Common;
    using WebApi2Book.Common.Logging;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var constraintsResolver = new DefaultInlineConstraintResolver();
            constraintsResolver.ConstraintMap.Add("apiVersionConstraint", typeof(ApiVersionConstraint));
            config.MapHttpAttributeRoutes(constraintsResolver);

            config.Services.Replace(typeof(IHttpControllerSelector), new NamespaceHttpControllerSelector(config));

            config.EnableSystemDiagnosticsTracing();
            config.Services.Replace(typeof(ITraceWriter), 
                new SimpleTraceWriter(WebContainerManager.Get<ILogManager>()));
        }
    }
}
