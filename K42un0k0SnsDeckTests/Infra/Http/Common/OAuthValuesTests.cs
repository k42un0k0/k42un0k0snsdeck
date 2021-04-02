using Xunit;
using System.Net;
using K42un0k0SnsDeck.Common;
using Moq;
using System;

namespace K42un0k0SnsDeck.Infra.Http.Common.Tests
{
    public class OAuthValuesTests
    {

        [Fact()]
        public void ComputedValueTestWhenRequestToken()
        {
            var mockUtilMethods = new Mock<UtilMethods>();
            mockUtilMethods.Setup((utilMethods) => utilMethods.RandomString(It.IsAny<int>())).Returns("JCKNUMB75U");
            mockUtilMethods.SetupGet((utilMethods) => utilMethods.UnixTimeSeconds).Returns(1617356469);
            UtilMethods.Singleton = mockUtilMethods.Object;
            var mockAppConfig = new Mock<AppConfig>();
            mockAppConfig.SetupGet((appConfig) => appConfig.TwitterApiKey).Returns("ULoMphmQLJ1gVY0q64Vp55UCc");
            mockAppConfig.SetupGet((appConfig) => appConfig.TwitterApiSecretKey).Returns("KwSTYBjLA9TksqF0pgozHvvJToXoJLkEDV3HgYMcG5v1JnHIul");
            AppConfig.Singleton = mockAppConfig.Object;
            // ↓postmanで作成した値
            var signatureExpect = "hNjZJBPWF/Toavf2ESTuntujkZg=";
            var headerExpect = "OAuth oauth_callback=\"https%3A%2F%2Flocalhost%3A8000\",oauth_consumer_key=\"ULoMphmQLJ1gVY0q64Vp55UCc\",oauth_nonce=\"JCKNUMB75U\",oauth_signature_method=\"HMAC-SHA1\",oauth_timestamp=\"1617356469\",oauth_version=\"1.0\",oauth_signature=\"hNjZJBPWF%2FToavf2ESTuntujkZg%3D\"";
            var oauthValues = new OAuthValues(TwitterUrl.REQUEST_TOKEN, WebRequestMethods.Http.Post);
            oauthValues.SetAcessTokenAndSecret("", "");
            oauthValues.AddParameter("oauth_callback", "https://localhost:8000");
            Assert.Equal(signatureExpect, oauthValues.Signature);
            Assert.Equal(headerExpect, oauthValues.Header);
        }
    }
}