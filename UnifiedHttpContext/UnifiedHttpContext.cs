#if NETFRAMEWORK
using System.Collections.Specialized;
using System.Web;
#elif NETCOREAPP
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System.Linq;
#endif
using System.IO;

namespace UnifiedHttpContextLib
{
    public class UnifiedHttpContext : IUnifiedHttpContext
    {
#if NETFRAMEWORK
        public System.Web.HttpContext HttpContext => System.Web.HttpContext.Current;

        public HttpRequest HttpRequest => HttpContext.Request;
        public string HttpMethod => HttpRequest.HttpMethod;
        public string Url => HttpRequest.Url.ToString();
        public string RawUrl => HttpRequest.RawUrl;
        public bool IsSecureConnection => HttpRequest.IsSecureConnection;

        public string UserAgent => HttpRequest.UserAgent;
        public string Browser => HttpRequest.Browser?.Type; // rough equivalent
        public string UserHostAddress => HttpRequest.UserHostAddress;

        public NameValueCollection Headers => HttpRequest.Headers;
        public NameValueCollection QueryString => HttpRequest.QueryString;
        public NameValueCollection Form => HttpRequest.Form;
        public HttpCookieCollection Cookies => HttpRequest.Cookies;
        public HttpFileCollection Files => HttpRequest.Files;

        public Stream InputStream => HttpRequest.InputStream;
#elif NETCOREAPP
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UnifiedHttpContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public Microsoft.AspNetCore.Http.HttpContext HttpContext => _httpContextAccessor.HttpContext;

        public HttpRequest HttpRequest => HttpContext.Request;
        public string Url =>
           $"{HttpRequest.Scheme}://{HttpRequest.Host}{HttpRequest.Path}{HttpRequest.QueryString}";

        public string RawUrl => $"{HttpRequest.Path}{HttpRequest.QueryString}";
        public bool IsSecureConnection => HttpRequest.IsHttps;

        public string UserAgent => HttpRequest.Headers["User-Agent"].FirstOrDefault();

        // No built-in Browser, return UserAgent (or use UAParser NuGet for richer info)
        public string Browser => UserAgent;

        public string UserHostAddress => HttpRequest.HttpContext.Connection.RemoteIpAddress?.ToString();


        public IHeaderDictionary Headers => HttpRequest.Headers;
        public IQueryCollection QueryString => HttpRequest.Query;
        public IFormCollection Form => HttpRequest.HasFormContentType ? HttpRequest.Form : new FormCollection(null);
        public IRequestCookieCollection Cookies => HttpRequest.Cookies;
        public IFormFileCollection Files => HttpRequest.HasFormContentType ? HttpRequest.Form.Files : new FormFileCollection();

        public Stream InputStream => HttpRequest.Body;
#endif
    }
}
