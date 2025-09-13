using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnifiedHttpContext
{
    public class HttpCachePolicyWrapper
    {
        private readonly HttpResponse _response;

        public HttpCachePolicyWrapper(HttpResponse response)
        {
            _response = response ?? throw new ArgumentNullException(nameof(response));
        }

        public void SetCacheability(string cacheability)
        {
            // Accept "public", "private", "no-cache"
            _response.Headers["Cache-Control"] = cacheability;
        }

        public void SetExpires(DateTime expires)
        {
            _response.Headers["Expires"] = expires.ToString("R");
        }

        public void SetNoStore()
        {
            _response.Headers["Cache-Control"] = "no-store";
        }

        public void SetValidUntilExpires(bool validUntil)
        {
            // Not directly supported, usually ignored in Core
            // Could store in header or ignore
        }

        public void SetRevalidation(string revalidation)
        {
            // Example: "proxy-revalidate" or "must-revalidate"
            _response.Headers["Cache-Control"] = revalidation;
        }
    }

}
