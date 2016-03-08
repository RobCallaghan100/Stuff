namespace WebApi2Book.Common.Routing
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Web.Http.Routing;

    public class ApiVersionConstraint : IHttpRouteConstraint
    {
        private readonly string _allowedVersion;

        public ApiVersionConstraint(string allowedVersion)
        {
            _allowedVersion = allowedVersion.ToLowerInvariant();
        }

        public bool Match(HttpRequestMessage request, IHttpRoute route, string parameterName, IDictionary<string, object> values,
            HttpRouteDirection routeDirection)
        {
            object value;

            if (values.TryGetValue(parameterName, out value) && value != null)
            {
                return _allowedVersion.Equals(value.ToString().ToLowerInvariant());
            }

            return false;
        }
    }
}
