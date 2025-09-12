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
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Collections;
using System.Drawing;


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

        public HttpResponse HttpResponse => HttpContext.Response;

        public Encoding HttpResponseContentEncoding 
        { 
            get => HttpResponse.ContentEncoding; 
            set => HttpResponse.ContentEncoding = value; 
        }
        public string HttpResponseContentType
        {
            get => HttpResponse.ContentType;
            set => HttpResponse.ContentType = value;
        }

        public int HttpResponseStatusCode
        {
            get => HttpResponse.StatusCode;
            set => HttpResponse.StatusCode = value;
        }

        public string HttpResponseStatusDescription
        {
            get => HttpResponse.StatusDescription;
            set => HttpResponse.StatusDescription = value;
        }

        public bool HttpResponseBuffer
        {
            get => HttpResponse.Buffer;
            set => HttpResponse.Buffer = value;
        }

        public bool HttpResponseIsClientConnected => HttpResponse.IsClientConnected;

        public Stream HttpResponseOutputStream => HttpResponse.OutputStream;

        public TextWriter HttpResponseOutput => HttpResponse.Output;

        public HttpCookieCollection HttpResponseCookies => HttpResponse.Cookies;

        public NameValueCollection HttpResponseHeaders => HttpResponse.Headers;

        public bool HttpResponseSuppressContent
        {
            get => HttpResponse.SuppressContent;
            set => HttpResponse.SuppressContent = value;
        }

        public string HttpResponseRedirectLocation
        {
            get => HttpResponse.RedirectLocation;
            set => HttpResponse.RedirectLocation = value;
        }

        public bool HttpResponseTrySkipIisCustomErrors
        {
            get => HttpResponse.TrySkipIisCustomErrors;
            set => HttpResponse.TrySkipIisCustomErrors = value;
        }

        public HttpCachePolicy HttpResponseCache => HttpResponse.Cache;

        public bool HttpResponseIsRequestBeingRedirected => HttpResponse.IsRequestBeingRedirected;


        #endregion
        #region HttpRequest Methods

        public void HttpRequestAbort() => HttpRequest.Abort();

        public byte[] HttpRequestBinaryRead(int count) => HttpRequest.BinaryRead(count);

        public Stream HttpRequestGetBufferedInputStream() => HttpRequest.GetBufferedInputStream();

        public Stream HttpRequestGetBufferlessInputStream() => HttpRequest.GetBufferlessInputStream();

        public Stream HttpRequestGetBufferlessInputStream(bool disableMaxRequestLength) => HttpRequest.GetBufferlessInputStream(disableMaxRequestLength);

        public int[] HttpRequestMapImageCoordinates(string imageFieldName) => HttpRequest.MapImageCoordinates(imageFieldName);

        public string HttpRequestMapPath(string virtualPath) => HttpRequest.MapPath(virtualPath);

        public void HttpRequestSaveAs(string filename, bool includeHeaders) => HttpRequest.SaveAs(filename, includeHeaders);

        public void HttpRequestValidateInput() => HttpRequest.ValidateInput();

        public void HttpResponseAddFileDependency(string filename) => HttpResponse.AddFileDependency(filename);
        public void HttpResponseAddHeader(string name, string value) => HttpResponse.AddHeader(name, value);
        public void HttpResponseAppendCookie(HttpCookie cookie) => HttpResponse.AppendCookie(cookie);
        public void HttpResponseAppendHeader(string name, string value) => HttpResponse.AppendHeader(name, value);
        public void HttpResponseBinaryWrite(byte[] buffer) => HttpResponse.BinaryWrite(buffer);
        public void HttpResponseClear() => HttpResponse.Clear();
        public void HttpResponseClearContent() => HttpResponse.ClearContent();
        public void HttpResponseClearHeaders() => HttpResponse.ClearHeaders();
        public void HttpResponseClose() => HttpResponse.Close();
        public void HttpResponseDisableKernelCache() => HttpResponse.DisableKernelCache();
        public void HttpResponseEnd() => HttpResponse.End();
        public void HttpResponseFlush() => HttpResponse.Flush();
        public void HttpResponseRedirect(string url) => HttpResponse.Redirect(url);
        public void HttpResponseRedirect(string url, bool endResponse) => HttpResponse.Redirect(url, endResponse);
        public void HttpResponseSetCookie(HttpCookie cookie) => HttpResponse.SetCookie(cookie);
        public void HttpResponseWrite(string s) => HttpResponse.Write(s);
        public void HttpResponseWrite(char ch) => HttpResponse.Write(ch);
        public void HttpResponseWrite(char[] buffer, int index, int count) => HttpResponse.Write(buffer, index, count);
        public void HttpResponseWriteFile(string filename) => HttpResponse.WriteFile(filename);
        public void HttpResponseWriteFile(string filename, bool readIntoMemory) => HttpResponse.WriteFile(filename, readIntoMemory);
        public void HttpResponseWriteFile(IntPtr fileHandle, long offset, long size) => HttpResponse.WriteFile(fileHandle, offset, size);

        #endregion


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
        public string[] HttpRequestUserLanguages => HttpRequest.Headers["Accept-Language"];
        public string HttpRequestApplicationPath => HttpContext.Request.PathBase;
        public void HttpRequestAbort() => HttpContext.Abort();

        #endregion
        // HttpContext-level properties
        public bool HttpRequestIsSecureConnection => HttpRequest.IsHttps;
        public string UserHostAddress => HttpRequest.HttpContext.Connection.RemoteIpAddress?.ToString();

        private const string AnonymousIdCookieName = "ANONYMOUS_ID";

        public string HttpRequestAnonymousID
        {
            get
            {
                var request = HttpContext.Request;
                var response = HttpContext.Response;

                // Check if cookie already exists
                if (request.Cookies.TryGetValue(AnonymousIdCookieName, out var existingId))
                {
                    return existingId;
                }

                // Otherwise generate a new one
                var newId = Guid.NewGuid().ToString();

                response.Cookies.Append(AnonymousIdCookieName, newId, new CookieOptions
                {
                    HttpOnly = true,
                    IsEssential = true,
                    Expires = DateTimeOffset.UtcNow.AddYears(1)
                });

                return newId;
            }
        }

        public string HttpRequestAppRelativeCurrentExecutionFilePath
        {
            get
            {
                // PathBase = app root (like /MyApp if app is hosted in a virtual dir)
                // Path = the request path within the app
                var pathBase = HttpContext.Request.PathBase.HasValue
                    ? HttpContext.Request.PathBase.Value
                    : string.Empty;

                var path = HttpContext.Request.Path.HasValue
                    ? HttpContext.Request.Path.Value
                    : string.Empty;

                // Combine and return relative style (~ + remaining path)
                if (!string.IsNullOrEmpty(path))
                {
                    return "~" + path;
                }

                // If no path, return just "~"
                return "~";
            }
        }

        public bool HttpRequestIsAuthenticated => HttpContext?.User?.Identity?.IsAuthenticated ?? false;

        public bool HttpRequestIsLocal
        {
            get
            {
                var connection = HttpContext?.Connection;
                if (connection == null)
                    return false;

                // If remote IP is not set, assume local
                if (connection.RemoteIpAddress == null)
                    return true;

                // Check if localhost (IPv4 or IPv6)
                if (IPAddress.IsLoopback(connection.RemoteIpAddress))
                    return true;

                // Compare RemoteIp with LocalIp
                return connection.LocalIpAddress != null &&
                       connection.RemoteIpAddress.Equals(connection.LocalIpAddress);
            }
        }

        public Stream HttpRequestFilter
        {
            get
            {
                // In .NET Core, Filter == Body (no extra filters supported)
                return HttpContext?.Request?.Body;
            }
        }

        public Encoding HttpRequestContentEncoding
        {
            get
            {
                var request = HttpContext?.Request;
                if (request == null)
                    return Encoding.UTF8; // default

                var charset = request.ContentType?
                    .Split(';')
                    .Select(part => part.Trim())
                    .FirstOrDefault(part => part.StartsWith("charset=", StringComparison.OrdinalIgnoreCase));

                if (charset != null)
                {
                    var encodingName = charset.Substring("charset=".Length);
                    try
                    {
                        return Encoding.GetEncoding(encodingName);
                    }
                    catch
                    {
                        // Unknown charset, fallback
                        return Encoding.UTF8;
                    }
                }

                return Encoding.UTF8; // default if no charset specified
            }
        }

        public string HttpRequestCurrentExecutionFilePath
        {
            get
            {
                var request = HttpContext?.Request;
                if (request == null)
                    return string.Empty;

                // Remove PathBase (application root) to mimic .NET Framework behavior
                var pathBase = request.PathBase.HasValue ? request.PathBase.Value : string.Empty;
                var path = request.Path.HasValue ? request.Path.Value : string.Empty;

                if (!string.IsNullOrEmpty(pathBase) && path.StartsWith(pathBase, StringComparison.OrdinalIgnoreCase))
                {
                    path = path.Substring(pathBase.Length);
                }

                return string.IsNullOrEmpty(path) ? "/" : path;
            }
        }

        public WindowsIdentity HttpRequestLogonUserIdentity
        {
            get
            {
                if (HttpContext?.User?.Identity is WindowsIdentity windowsIdentity)
                    return windowsIdentity;

                // Optional: fallback to null if not Windows-authenticated
                return null;
            }
        }
        public string HttpRequestPath
        {
            get
            {
                return HttpContext?.Request?.Path.HasValue == true
                    ? HttpContext.Request.Path.Value
                    : string.Empty;
            }
        }

        public string HttpRequestPathInfo
        {
            get
            {
                var request = HttpContext?.Request;
                if (request == null) return string.Empty;

                // Example: treat PathBase + Path as the resource base, and everything else as PathInfo
                var pathBase = request.PathBase.HasValue ? request.PathBase.Value : string.Empty;
                var path = request.Path.HasValue ? request.Path.Value : string.Empty;

                // In Core, often PathInfo is empty because routing handles the extra segments
                // Here, we just simulate by removing PathBase
                if (!string.IsNullOrEmpty(pathBase) && path.StartsWith(pathBase, StringComparison.OrdinalIgnoreCase))
                {
                    path = path.Substring(pathBase.Length);
                }

                return path; // This mimics PathInfo if needed
            }
        }

        public string HttpRequestPhysicalApplicationPath
        {
            get
            {
                return AppContext.BaseDirectory;
            }
        }


        public string HttpRequestPhysicalPath
        {
            get
            {
                if (HttpRequest == null)
                    return string.Empty;

                // Application root fallback
                string appRoot = AppContext.BaseDirectory;

                // Get Path relative to PathBase
                var pathBase = HttpRequest.PathBase.HasValue ? HttpRequest.PathBase.Value : string.Empty;
                var path = HttpRequest.Path.HasValue ? HttpRequest.Path.Value : string.Empty;

                if (!string.IsNullOrEmpty(pathBase) && path.StartsWith(pathBase, StringComparison.OrdinalIgnoreCase))
                {
                    path = path.Substring(pathBase.Length);
                }

                // Remove leading slashes and normalize separators
                path = path.TrimStart('/').Replace('/', Path.DirectorySeparatorChar);

                return Path.Combine(appRoot, path);
            }
        }
        public UnifiedReadEntityBodyMode HttpRequestReadEntityBodyMode => UnifiedReadEntityBodyMode.Classic;

        // ✅ Equivalent to HttpRequest.RequestContext (not really a thing in Core)
        // You could expose HttpContext.Items instead — works as a per-request dictionary.
        public IDictionary<object, object> HttpRequestRequestContext => HttpContext.Items;

        // ✅ Equivalent to HttpRequest.RequestType ("GET", "POST", etc.)
        public string HttpRequestRequestType => HttpRequest.Method;

        // ✅ Equivalent to HttpRequest.ServerVariables
        // Core has no ServerVariables, but you can expose headers as closest thing.
        public IHeaderDictionary HttpRequestServerVariables => HttpRequest.Headers;

        // ✅ Equivalent to HttpRequest.TotalBytes
        // This reads the Content-Length header if present.
        public int HttpRequestTotalBytes => (int)(HttpRequest.ContentLength ?? 0);

        private async Task<string> HttpRequestUserHostNameHelper()
        {
            var ipAddress = HttpContext.Connection.RemoteIpAddress;
            if (ipAddress == null)
                return string.Empty;

            try
            {
                var hostEntry = await Dns.GetHostEntryAsync(ipAddress);
                return hostEntry.HostName;
            }
            catch
            {
                return ipAddress.ToString(); // fallback
            }
        }
        public Task<string> HttpRequestUserHostAddress => Task.FromResult(HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown");

        public Task<string> HttpRequestUserHostName => HttpRequestUserHostNameHelper();


#endif
    }
}
