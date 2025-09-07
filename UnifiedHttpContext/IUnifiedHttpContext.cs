#if NETFRAMEWORK
using System.Collections.Specialized;
using System.Web;
using System.Web.Routing;
#elif NETCOREAPP
using Microsoft.AspNetCore.Http;
#endif
using System.IO;
using System.Linq;
using System;
using System.Text;
using System.Security.Principal;

namespace UnifiedHttpContextLib
{
    public interface IUnifiedHttpContext
    {
#if NETFRAMEWORK
        HttpContext HttpContext { get; }

        #region HttpRequest Properties
        string[] HttpRequestAcceptTypes { get; }
        string HttpRequestApplicationPath { get; }
        string HttpRequestAnonymousID { get; }
        string HttpRequestAppRelativeCurrentExecutionFilePath { get; }
        HttpBrowserCapabilities HttpRequestBrowser { get; }
        bool HttpRequestIsAuthenticated { get; }
        bool HttpRequestIsLocal { get; }
        bool HttpRequestIsSecureConnection { get; }
        HttpCookieCollection HttpRequestCookies { get; }
        Stream HttpRequestFilter { get; }
        Encoding HttpRequestContentEncoding { get; }
        long? HttpRequestContentLength { get; }
        string HttpRequestContentType { get; }
        string HttpRequestCurrentExecutionFilePath { get; }
        HttpFileCollection HttpRequestFiles { get; }
        NameValueCollection HttpRequestForm { get; }
        NameValueCollection HttpRequestHeaders { get; }
        Stream HttpRequestInputStream { get; }
        WindowsIdentity HttpRequestLogonUserIdentity { get; }
        NameValueCollection HttpRequestParams { get; }
        string HttpRequestPath { get; }
        string HttpRequestPathInfo { get; }
        string HttpRequestPhysicalApplicationPath { get; }
        string HttpRequestPhysicalPath { get; }
        NameValueCollection HttpRequestQueryString { get; }
        string HttpRequestRawUrl { get; }
        ReadEntityBodyMode HttpRequestReadEntityBodyMode { get; }
        RequestContext HttpRequestRequestContext { get; }
        string HttpRequestRequestType { get; }
        NameValueCollection HttpRequestServerVariables { get; }
        int HttpRequestTotalBytes { get; }
        Uri HttpRequestUrl { get; }
        Uri HttpRequestUrlReferrer { get; }
        string HttpRequestUserAgent { get; }
        string HttpRequestUserHostAddress { get; }
        string HttpRequestUserHostName { get; }
        string[] HttpRequestUserLanguages { get; }
        HttpRequest HttpRequest { get; }
        #endregion
        void HttpRequestAbort();


#elif NETCOREAPP
        HttpContext HttpContext { get; }
        HttpRequest HttpRequest { get; }

        // HttpRequest-prefixed properties
        void HttpRequestAbort();
        #region HttpRequest Properties
        string HttpRequestMethod { get; }
        string HttpRequestUrl { get; }
        string HttpRequestRawUrl { get; }
        string HttpRequestUserAgent { get; }
        string HttpRequestBrowser { get; }
        IHeaderDictionary HttpRequestHeaders { get; }
        IQueryCollection HttpRequestQueryString { get; }
        IFormCollection HttpRequestForm { get; }
        IRequestCookieCollection HttpRequestCookies { get; }
        IFormFileCollection HttpRequestFiles { get; }
        Stream HttpRequestInputStream { get; }
        public string[] HttpRequestAcceptTypes { get; }
        public long? HttpRequestContentLength { get; }
        public string HttpRequestContentType { get; }
        public string HttpRequestUrlReferrer { get; }
        public string HttpRequestUserLanguages  { get; }
        public string HttpRequestApplicationPath { get; }
        #endregion
        // HttpContext-level properties
        bool IsSecureConnection { get; }
        string UserHostAddress { get; }
#endif
    }
}
