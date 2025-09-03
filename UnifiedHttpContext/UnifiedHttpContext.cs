#if NETFRAMEWORK
using System.Web;
#elif NETCOREAPP
using Microsoft.AspNetCore.Http;
#endif
namespace UnifiedHttpContext
{
    public class UnifiedHttpContext : IUnifiedHttpContext
    {
#if NETFRAMEWORK
        public HttpContext GetUnifiedHttpContext() => HttpContext.Current;
#elif NETCOREAPP
        public HttpContext GetUnifiedHttpContext(IHttpContextAccessor httpContextAccessor) => httpContextAccessor.HttpContext;
#endif
    }
}
