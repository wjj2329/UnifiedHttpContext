#if NETFRAMEWORK
using System.Collections.Specialized;
using System.Web;
using System.Web.Routing;
#elif NETCOREAPP
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System.Linq;
#endif
using System.IO;
using System;
using System.Text;
using System.Security.Principal;

namespace UnifiedHttpContextLib
{
    public class UnifiedHttpContext : IUnifiedHttpContext
    {
#if NETFRAMEWORK
        public HttpContext HttpContext => HttpContext.Current;

        public HttpRequest HttpRequest => HttpContext.Request;

        #region HttpRequest Properties
        public string[] HttpRequestAcceptTypes => HttpRequest.AcceptTypes;
        public string HttpRequestApplicationPath => HttpRequest.ApplicationPath;
        public string HttpRequestAnonymousID => HttpRequest.AnonymousID;
        public string HttpRequestAppRelativeCurrentExecutionFilePath => HttpRequest.AppRelativeCurrentExecutionFilePath;
        public HttpBrowserCapabilities HttpRequestBrowser => HttpRequest.Browser;
        public bool HttpRequestIsAuthenticated => HttpRequest.IsAuthenticated;
        public bool HttpRequestIsLocal => HttpRequest.IsLocal;
        public bool HttpRequestIsSecureConnection => HttpRequest.IsSecureConnection;
        public HttpCookieCollection HttpRequestCookies => HttpRequest.Cookies;
        public Stream HttpRequestFilter => HttpRequest.Filter;
        public Encoding HttpRequestContentEncoding => HttpRequest.ContentEncoding;
        public long? HttpRequestContentLength => HttpRequest.ContentLength;
        public string HttpRequestContentType => HttpRequest.ContentType;
        public string HttpRequestCurrentExecutionFilePath => HttpRequest.CurrentExecutionFilePath;
        public HttpFileCollection HttpRequestFiles => HttpRequest.Files;
        public NameValueCollection HttpRequestForm => HttpRequest.Form;
        public NameValueCollection HttpRequestHeaders => HttpRequest.Headers;
        public string HttpRequestHttpMethod => HttpRequest.HttpMethod;
        public Stream HttpRequestInputStream => HttpRequest.InputStream;
        public WindowsIdentity HttpRequestLogonUserIdentity => HttpRequest.LogonUserIdentity;
        public NameValueCollection HttpRequestParams => HttpRequest.Params;
        public string HttpRequestPath => HttpRequest.Path;
        public string HttpRequestPathInfo => HttpRequest.PathInfo;
        public string HttpRequestPhysicalApplicationPath => HttpRequest.PhysicalApplicationPath;
        public string HttpRequestPhysicalPath => HttpRequest.PhysicalPath;
        public NameValueCollection HttpRequestQueryString => HttpRequest.QueryString;
        public string HttpRequestRawUrl => HttpRequest.RawUrl;
        public ReadEntityBodyMode HttpRequestReadEntityBodyMode => HttpRequest.ReadEntityBodyMode;
        public RequestContext HttpRequestRequestContext => HttpRequest.RequestContext;
        public string HttpRequestRequestType => HttpRequest.RequestType;
        public NameValueCollection HttpRequestServerVariables => HttpRequest.ServerVariables;
        public int HttpRequestTotalBytes => HttpRequest.TotalBytes;
        public string[] HttpRequestUserLanguages => HttpRequest.UserLanguages;
        public string HttpRequestUserHostAddress => HttpRequest.UserHostAddress;
        public string HttpRequestUserHostName => HttpRequest.UserHostName;
        public string HttpRequestUserAgent => HttpRequest.UserAgent;
        public Uri HttpRequestUrl => HttpRequest.Url;
        public Uri HttpRequestUrlReferrer => HttpRequest.UrlReferrer;
        public bool IsSecureConnection => HttpRequest.IsSecureConnection;
        public string UserHostAddress => HttpRequest.UserHostAddress;


        #endregion

        public void HttpRequestAbort() => HttpRequest.Abort();


#elif NETCOREAPP
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UnifiedHttpContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public HttpContext HttpContext => _httpContextAccessor.HttpContext;

        public HttpRequest HttpRequest => HttpContext.Request;

        // HttpRequest-prefixed properties
        #region HttpRequest Properties

        public string HttpRequestUrl =>
           $"{HttpRequest.Scheme}://{HttpRequest.Host}{HttpRequest.Path}{HttpRequest.QueryString}";

        public string HttpRequestRawUrl => $"{HttpRequest.Path}{HttpRequest.QueryString}";
        public string HttpRequestMethod => HttpRequest.Method;
        public string HttpRequestUserAgent => HttpRequest.Headers["User-Agent"].FirstOrDefault();
        public string HttpRequestBrowser => HttpRequestUserAgent; // no built-in Browser
        public IHeaderDictionary HttpRequestHeaders => HttpRequest.Headers;
        public IQueryCollection HttpRequestQueryString => HttpRequest.Query;
        public IFormCollection HttpRequestForm => HttpRequest.HasFormContentType ? HttpRequest.Form : new FormCollection(null);
        public IRequestCookieCollection HttpRequestCookies => HttpRequest.Cookies;
        public IFormFileCollection HttpRequestFiles => HttpRequest.HasFormContentType ? HttpRequest.Form.Files : new FormFileCollection();
        public Stream HttpRequestInputStream => HttpRequest.Body;
        public string[] HttpRequestAcceptTypes =>
            HttpRequest.Headers["Accept"].FirstOrDefault()?.Split(',') ?? Array.Empty<string>();

        public long? HttpRequestContentLength => HttpRequest.ContentLength;
        public string HttpRequestContentType => HttpRequest.ContentType;
        public string HttpRequestUrlReferrer => HttpRequest.Headers["Referer"].FirstOrDefault();
        public string HttpRequestUserLanguages => HttpRequest.Headers["Accept-Language"].FirstOrDefault();
        public string HttpRequestApplicationPath => HttpContext.Request.PathBase;
        public void HttpRequestAbort() => HttpContext.Abort();

        #endregion
        // HttpContext-level properties
        public bool IsSecureConnection => HttpRequest.IsHttps;
        public string UserHostAddress => HttpRequest.HttpContext.Connection.RemoteIpAddress?.ToString();
#endif
    }
}
