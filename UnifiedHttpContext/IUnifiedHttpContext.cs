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
using System.Collections.Generic;
using System.Threading.Tasks;

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
        string[] HttpRequestAcceptTypes { get; }
        string HttpRequestApplicationPath { get; }
        string HttpRequestAnonymousID { get; } // Needs to be implemented by user
        string HttpRequestAppRelativeCurrentExecutionFilePath { get; } // Optional, may map to PathBase
        string HttpRequestBrowser { get; } // Optional: Core doesn't have HttpBrowserCapabilities
        bool HttpRequestIsAuthenticated { get; }
        bool HttpRequestIsLocal { get; }
        bool HttpRequestIsSecureConnection { get; }
        IRequestCookieCollection HttpRequestCookies { get; }
        Stream HttpRequestFilter { get; }
        Encoding HttpRequestContentEncoding { get; }
        long? HttpRequestContentLength { get; }
        string HttpRequestContentType { get; }
        string HttpRequestCurrentExecutionFilePath { get; } // Optional
        IFormFileCollection HttpRequestFiles { get; }
        IFormCollection HttpRequestForm { get; }
        IHeaderDictionary HttpRequestHeaders { get; }
        Stream HttpRequestInputStream { get; }
        WindowsIdentity HttpRequestLogonUserIdentity { get; } // Optional
        IQueryCollection HttpRequestQueryString { get; }
        string HttpRequestPath { get; }
        string HttpRequestPathInfo { get; } // Optional, can map to Path
        string HttpRequestPhysicalApplicationPath { get; } // Optional
        string HttpRequestPhysicalPath { get; } // Optional
        string HttpRequestRawUrl { get; }
        UnifiedReadEntityBodyMode HttpRequestReadEntityBodyMode { get; } // Optional
        IDictionary<string, object> HttpRequestRequestContext { get; } // Optional
        string HttpRequestRequestType { get; } // Maps to HttpRequest.Method
        IHeaderDictionary HttpRequestServerVariables { get; } // Optional mapping
        int HttpRequestTotalBytes { get; } // Optional
        string HttpRequestUserAgent { get; }
        Task<string> HttpRequestUserHostName { get; } // Optional
        string[] HttpRequestUserLanguages { get; } // Optional
        string HttpRequestUrl { get; }
        string HttpRequestUrlReferrer { get; }
        string HttpRequestMethod { get; }
        #endregion

        // HttpContext-level properties
        bool IsSecureConnection { get; }
        Task<string> HttpRequestUserHostAddress { get; }
#endif
    }
}
