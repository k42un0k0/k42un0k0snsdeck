using System;
using System.Web;
using Xunit;

namespace K42un0k0SnsDeckTests.TestUtil
{
    public class SampleTests
    {
        [Fact()]
        public void CodeTest()
        {

            var uri = new Uri("https://google.com?s=aaaa");
            var query = HttpUtility.ParseQueryString(uri.Query);

            Assert.Equal("aaaa", query["s"]);
        }
    }
}