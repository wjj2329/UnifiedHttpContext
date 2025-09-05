using System;
#if NETFRAMEWORK
using System.IO;
using System.Web;
using System.Collections.Specialized;
#elif NETCOREAPP
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
#endif

namespace UnifiedHttpContextTest
{
    public static class TestHttpContextFactory
    {
#if NETFRAMEWORK
        public static HttpContext CreateFrameworkContext()
        {
            var request = new HttpRequest("", "http://localhost/", "param1=val1");

            request.Headers.Add("User-Agent", "UnitTestAgent");
            request.Form.Add("FormKey", "FormValue");

            var response = new HttpResponse(new StringWriter());
            var ctx = new HttpContext(request, response);
            HttpContext.Current = ctx;
            return ctx;
        }
#elif NETCOREAPP
        public static IHttpContextAccessor CreateCoreContext()
        {
            var context = new DefaultHttpContext();

            context.Request.Scheme = "http";
            context.Request.Host = new HostString("localhost");
            context.Request.Path = "/test";
            context.Request.QueryString = new QueryString("?param1=val1");
            context.Request.Headers["User-Agent"] = "UnitTestAgent";
            context.Request.Form = new FormCollection(new Dictionary<string, Microsoft.Extensions.Primitives.StringValues>
            {
                { "FormKey", "FormValue" }
            });

            return new HttpContextAccessor { HttpContext = context };
        }
#endif
    }
}
