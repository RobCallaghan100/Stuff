namespace WebApi2Book.Common.Security
{
    using System;
    using System.Security.Claims;
    using System.Web;

    public class UserSession :IWebUserSession
    {
        public string FirstName
        {
            get { return ((ClaimsPrincipal) HttpContext.Current.User).FindFirst(ClaimTypes.GivenName).Value; }
        }

        public string LastName
        {
            get { return ((ClaimsPrincipal) HttpContext.Current.User).FindFirst(ClaimTypes.Surname).Value; }
        }

        public string UserName { get { return ((ClaimsPrincipal)HttpContext.Current.User).FindFirst(ClaimTypes.Name).Value; } }
        public bool IsInRole(string roleName)
        {
            return HttpContext.Current.User.IsInRole(roleName);
        }

        public string ApiVersionInUse
        {
            get
            {
                const int versionIndex = 0;
                if (HttpContext.Current.Request.Url.Segments.Length < versionIndex + 1)
                {
                    return string.Empty;
                }

                var apiVersionInUse = HttpContext.Current.Request
                    .Url.Segments[versionIndex].Replace("/", String.Empty);

                return apiVersionInUse;
            }
        }

        public Uri RequestUri { get; }
        public string HttpRequestMethod { get; }
    }
}
