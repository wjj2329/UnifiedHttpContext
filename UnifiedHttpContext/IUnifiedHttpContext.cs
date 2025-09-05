#if NETFRAMEWORK
using System.Collections.Specialized;
using System.Web;
#elif NETCOREAPP
using Microsoft.AspNetCore.Http;
#endif
using System.IO;
using System.Linq;
using System;

namespace UnifiedHttpContextLib
{
    public interface IUnifiedHttpContext
    {
#if NETFRAMEWORK
        HttpContext HttpContext { get; }

        #region HttpRequest Properties
        HttpRequest HttpRequest { get; }
        void HttpRequestAbort(); 

        string[] HttpRequestAcceptTypes { get; }
        string HttpRequestApplicationPath { get; }
        string HttpRequestBrowser { get; }
        HttpCookieCollection HttpRequestCookies { get; }
        string HttpRequestContentType { get; }
        long? HttpRequestContentLength { get; }
        NameValueCollection HttpRequestForm { get; }
        NameValueCollection HttpRequestHeaders { get; }
        Stream HttpRequestInputStream { get; }
        NameValueCollection HttpRequestQueryString { get; }
        string HttpRequestHttpMethod { get; }
        HttpFileCollection HttpRequestFiles { get; }
        string HttpRequestRawUrl { get; }
        string HttpRequestUserAgent { get; }
        string[] HttpRequestUserLanguages { get; }
        Uri HttpRequestUrlReferrer { get; }
        string HttpRequestUrl { get; }
        #endregion

        // HttpContext-level properties
        bool IsSecureConnection { get; }
        string UserHostAddress { get; }

#elif NETCOREAPP
        HttpContext HttpContext { get; }
        HttpRequest HttpRequest { get; }

        // HttpRequest-prefixed properties
        void HttpRequestAbort();

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
        // HttpContext-level properties
        bool IsSecureConnection { get; }
        string UserHostAddress { get; }
#endif
    }
}
