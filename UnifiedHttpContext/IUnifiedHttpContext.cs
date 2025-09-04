#if NETFRAMEWORK
using System.Collections.Specialized;
using System.Web;
#elif NETCOREAPP
using Microsoft.AspNetCore.Http;
#endif
using System.IO;

namespace UnifiedHttpContextLib
{
    public interface IUnifiedHttpContext
    {
#if NETFRAMEWORK
        System.Web.HttpContext HttpContext { get; }
        HttpRequest HttpRequest { get; }
        string HttpMethod { get; }
        string Url { get; }
        string RawUrl { get; }
        bool IsSecureConnection { get; }

        string UserAgent { get; }
        string Browser { get; }
        string UserHostAddress { get; }

        NameValueCollection Headers { get; }
        NameValueCollection QueryString { get; }
        NameValueCollection Form { get; }
        HttpCookieCollection Cookies { get; }
        HttpFileCollection Files { get; }

        Stream InputStream { get; }
#elif NETCOREAPP
        public Microsoft.AspNetCore.Http.HttpContext HttpContext { get; }
        public HttpRequest HttpRequest { get; }
        public string Url { get; }

        public string RawUrl { get; }
        public bool IsSecureConnection { get; }

        public string UserAgent { get; }

        // No built-in Browser, return UserAgent (or use UAParser NuGet for richer info)
        public string Browser { get; }

        public string UserHostAddress { get; }

        public IHeaderDictionary Headers { get; }
        public IQueryCollection QueryString { get; }
        public IFormCollection Form { get; }
        public IRequestCookieCollection Cookies { get; }
        public IFormFileCollection Files { get; }

        public Stream InputStream { get; }
#endif
    }
}
    