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
using System.Collections.Specialized;
using UnifiedHttpContext;

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
        #region HttpRequest Methods
        void HttpRequestAbort();
        byte[] HttpRequestBinaryRead(int count);
        Stream HttpRequestGetBufferedInputStream();
        Stream HttpRequestGetBufferlessInputStream();
        Stream HttpRequestGetBufferlessInputStream(bool disableMaxRequestLength);
        int[] HttpRequestMapImageCoordinates(string imageFieldName);
        string HttpRequestMapPath(string virtualPath);
        void HttpRequestSaveAs(string filename, bool includeHeaders);
        void HttpRequestValidateInput();
        #endregion
        #region HttpResponse Properties
        HttpResponse HttpResponse { get; }
        Encoding HttpResponseContentEncoding { get; set; }
        string HttpResponseContentType { get; set; }
        int HttpResponseStatusCode { get; set; }
        string HttpResponseStatusDescription { get; set; }
        bool HttpResponseBuffer { get; set; }
        bool HttpResponseIsClientConnected { get; }

        Stream HttpResponseOutputStream { get; }
        TextWriter HttpResponseOutput { get; }

        HttpCookieCollection HttpResponseCookies { get; }
        NameValueCollection HttpResponseHeaders { get; }

        bool HttpResponseSuppressContent { get; set; }
        string HttpResponseRedirectLocation { get; set; }

        bool HttpResponseTrySkipIisCustomErrors { get; set; }
        HttpCachePolicy HttpResponseCache { get; }
        bool HttpResponseIsRequestBeingRedirected { get; }
        #endregion
        #region HttpResponse Methods
        // Writing / output
        void HttpResponseWrite(string s);
        void HttpResponseWrite(char ch);
        void HttpResponseWrite(char[] buffer, int index, int count);
        void HttpResponseWriteFile(string filename);
        void HttpResponseWriteFile(string filename, bool readIntoMemory);
        void HttpResponseWriteFile(IntPtr fileHandle, long offset, long size);

        // Flushing / buffering
        void HttpResponseFlush();
        void HttpResponseClear();
        void HttpResponseClearContent();
        void HttpResponseClearHeaders();
        void HttpResponseEnd();

        // Redirection
        void HttpResponseRedirect(string url);
        void HttpResponseRedirect(string url, bool endResponse);

        // Compression / buffering
        void HttpResponseAddFileDependency(string filename);
        void HttpResponseAddHeader(string name, string value);
        void HttpResponseAppendCookie(HttpCookie cookie);
        void HttpResponseAppendHeader(string name, string value);

        // Misc / lifecycle
        void HttpResponseBinaryWrite(byte[] buffer);
        void HttpResponseClose();
        void HttpResponseDisableKernelCache();
        void HttpResponseSetCookie(HttpCookie cookie);
        #endregion
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
        IDictionary<object, object> HttpRequestRequestContext { get; } // Optional
        string HttpRequestRequestType { get; } // Maps to HttpRequest.Method
        IHeaderDictionary HttpRequestServerVariables { get; } // Optional mapping
        int HttpRequestTotalBytes { get; } // Optional
        string HttpRequestUserAgent { get; }
        Task<string> HttpRequestUserHostName { get; } // Optional
        string[] HttpRequestUserLanguages { get; } // Optional
        string HttpRequestUrl { get; }
        string HttpRequestUrlReferrer { get; }
        string HttpRequestMethod { get; }
        Task<string> HttpRequestUserHostAddress { get; }
        #endregion
        #region HttpResponse Properties
        HttpResponse HttpResponse { get; }
        Encoding HttpResponseContentEncoding { get; set; }
        string HttpResponseContentType { get; set; }
        int HttpResponseStatusCode { get; set; }
        string HttpResponseStatusDescription { get; set; }
        bool HttpResponseBuffer { get; set; }
        bool HttpResponseIsClientConnected { get; }

        Stream HttpResponseOutputStream { get; }
        TextWriter HttpResponseOutput { get; }

        HttpCookieCollectionWrapper HttpResponseCookies { get; }
        NameValueCollection HttpResponseHeaders { get; }

        bool HttpResponseSuppressContent { get; set; }
        string HttpResponseRedirectLocation { get; set; }

        bool HttpResponseTrySkipIisCustomErrors { get; set; }
        HttpCachePolicyWrapper HttpResponseCache { get; }
        bool HttpResponseIsRequestBeingRedirected { get; }
        #endregion
        #region HttpResponse Methods
        // Writing / output
        void HttpResponseWrite(string s);
        void HttpResponseWrite(char ch);
        void HttpResponseWrite(char[] buffer, int index, int count);
        void HttpResponseWriteFile(string filename);
        void HttpResponseWriteFile(string filename, bool readIntoMemory);
        void HttpResponseWriteFile(IntPtr fileHandle, long offset, long size);

        // Flushing / buffering
        void HttpResponseFlush();
        void HttpResponseClear();
        void HttpResponseClearContent();
        void HttpResponseClearHeaders();
        void HttpResponseEnd();

        // Redirection
        void HttpResponseRedirect(string url);
        void HttpResponseRedirect(string url, bool endResponse);

        // Compression / buffering
        void HttpResponseAddFileDependency(string filename);
        void HttpResponseAddHeader(string name, string value);
        void HttpResponseAppendCookie(string key, string value, CookieOptions options = null);
        void HttpResponseAppendHeader(string name, string value);

        // Misc / lifecycle
        void HttpResponseBinaryWrite(byte[] buffer);
        void HttpResponseClose();
        void HttpResponseDisableKernelCache();
        void HttpResponseSetCookie(string key, string value, CookieOptions options = null);
        #endregion
#endif
    }
}
