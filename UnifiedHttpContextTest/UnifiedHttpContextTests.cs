using Xunit;
using UnifiedHttpContextTest;
using UnifiedHttpContextLib;


#if NETFRAMEWORK
using System.Web;
#elif NETCOREAPP
using Microsoft.AspNetCore.Http;
#endif
namespace UnifiedHttpContextTest
{
    public class UnifiedHttpContextTest
    {
#if NETFRAMEWORK
        [Fact]
        public void Url_Returns_CorrectValue_Framework()
        {
            TestHttpContextFactory.CreateFrameworkContext();
            var unified = new UnifiedHttpContextLib.UnifiedHttpContext();

            Assert.Equal("http://localhost/", unified.HttpRequestUrl);
            Assert.Equal("/?param1=val1", unified.HttpRequestRawUrl);
            Assert.Contains("UnitTestAgent", unified.HttpRequestUserAgent);
        }

        [Fact]
        public void QueryString_Form_Headers_Framework()
        {
            TestHttpContextFactory.CreateFrameworkContext();
            var unified = new UnifiedHttpContextLib.UnifiedHttpContext();

            Assert.Equal("val1", unified.HttpRequestQueryString["param1"]);
            Assert.Equal("FormValue", unified.HttpRequestForm["FormKey"].ToString());
            Assert.Equal("UnitTestAgent", unified.HttpRequestHeaders["User-Agent"]);
        }
#elif NETCOREAPP
        [Fact]
        public void Url_Returns_CorrectValue_Core()
        {
            var accessor = TestHttpContextFactory.CreateCoreContext();
            var unified = new UnifiedHttpContextLib.UnifiedHttpContext(accessor);

            Assert.Equal("http://localhost/test?param1=val1", unified.HttpRequestUrl);
            Assert.Equal("/test?param1=val1", unified.HttpRequestRawUrl);
            Assert.Equal("UnitTestAgent", unified.HttpRequestUserAgent);
        }

        [Fact]
        public void QueryString_Form_Headers_Core()
        {
            var accessor = TestHttpContextFactory.CreateCoreContext();
            var unified = new UnifiedHttpContextLib.UnifiedHttpContext(accessor);

            Assert.Equal("val1", unified.HttpRequestQueryString["param1"]);
            Assert.Equal("FormValue", unified.HttpRequestForm["FormKey"]);
            Assert.Equal("UnitTestAgent", unified.HttpRequestHeaders["User-Agent"]);
        }
#endif
    }
}
