using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using System.Collections.Generic;
namespace UnifiedHttpContext
{

    public class HttpCookieCollectionWrapper : IEnumerable<HttpCookieWrapper>
    {
        private readonly HttpContext _context;

        public HttpCookieCollectionWrapper(HttpContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // Get cookie by name
        public HttpCookieWrapper this[string name] =>
            _context.Request.Cookies.TryGetValue(name, out var value)
                ? new HttpCookieWrapper(name, value)
                : null;

        // Add a cookie to the response
        public void Add(HttpCookieWrapper cookie)
        {
            if (cookie == null) throw new ArgumentNullException(nameof(cookie));
            _context.Response.Cookies.Append(cookie.Name, cookie.Value, cookie.Options);
        }

        // Remove a cookie from the response
        public void Remove(string name)
        {
            _context.Response.Cookies.Delete(name);
        }

        // Enumerate cookies (request cookies)
        public IEnumerator<HttpCookieWrapper> GetEnumerator()
        {
            foreach (var kvp in _context.Request.Cookies)
            {
                yield return new HttpCookieWrapper(kvp.Key, kvp.Value);
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    // Simple wrapper for individual cookies
    public class HttpCookieWrapper
    {
        public string Name { get; }
        public string Value { get; set; }
        public CookieOptions Options { get; }

        public HttpCookieWrapper(string name, string value, CookieOptions options = null)
        {
            Name = name;
            Value = value;
            Options = options ?? new CookieOptions();
        }
    }
}
