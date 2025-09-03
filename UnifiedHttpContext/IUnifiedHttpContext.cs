#if NETFRAMEWORK
using System.Web;
#elif NETCOREAPP
using Microsoft.AspNetCore.Http;
#endif
namespace UnifiedHttpContext
{
    public interface IUnifiedHttpContext
    {
#if NETFRAMEWORK
        HttpContext GetUnifiedHttpContext();
#elif NETCOREAPP
        public HttpContext GetUnifiedHttpContext(IHttpContextAccessor httpContextAccessor);
#endif
    }
}
    