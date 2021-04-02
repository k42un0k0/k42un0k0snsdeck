using Xunit;
using System;
using K42un0k0SnsDeck.Infra.Http;
using K42un0k0SnsDeck.DomainModels.TwitterAccount;
using K42un0k0SnsDeckTests.TestUtil;

namespace K42un0k0SnsDeckTests.Infra.Http
{
    public class TwitterClientTests
    {
        [Fact()]
        public void GetAccountNameTest()
        {
            MockUtil.mockAppConfig();
            var httpClient = MockUtil.mockResponseText("{\"name\" : \"hello\"}");
            var twitterClient = new TwitterClient();
            twitterClient.httpClient = httpClient;
            var credentials = new TwitterAccountCredentials("accesstoken","accesstokensecret");
            Assert.Equal("hello", twitterClient.GetAccountName(credentials));
        }
    }
}