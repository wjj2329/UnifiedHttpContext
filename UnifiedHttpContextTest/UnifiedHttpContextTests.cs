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

            Assert.Equal("http://localhost/", unified.Url);
            Assert.Equal("/?param1=val1", unified.RawUrl);
            Assert.Contains("UnitTestAgent", unified.UserAgent);
        }

        [Fact]
        public void QueryString_Form_Headers_Framework()
        {
            TestHttpContextFactory.CreateFrameworkContext();
            var unified = new UnifiedHttpContextLib.UnifiedHttpContext();

            Assert.Equal("val1", unified.QueryString["param1"]);
            Assert.Equal("FormValue", unified.Form["FormKey"].ToString());
            Assert.Equal("UnitTestAgent", unified.Headers["User-Agent"]);
        }
#elif NETCOREAPP
        [Fact]
        public void Url_Returns_CorrectValue_Core()
        {
            var accessor = TestHttpContextFactory.CreateCoreContext();
            var unified = new UnifiedHttpContextLib.UnifiedHttpContext(accessor);

            Assert.Equal("http://localhost/test?param1=val1", unified.Url);
            Assert.Equal("/test?param1=val1", unified.RawUrl);
            Assert.Equal("UnitTestAgent", unified.UserAgent);
        }

        [Fact]
        public void QueryString_Form_Headers_Core()
        {
            var accessor = TestHttpContextFactory.CreateCoreContext();
            var unified = new UnifiedHttpContextLib.UnifiedHttpContext(accessor);

            Assert.Equal("val1", unified.QueryString["param1"]);
            Assert.Equal("FormValue", unified.Form["FormKey"]);
            Assert.Equal("UnitTestAgent", unified.Headers["User-Agent"]);
        }
#endif
    }
}
