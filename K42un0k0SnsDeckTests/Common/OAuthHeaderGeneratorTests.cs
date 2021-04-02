using Xunit;
using System.Net;
using K42un0k0SnsDeck.Common;
using Moq;
using K42un0k0SnsDeck.Constants;

namespace K42un0k0SnsDeckTests.Common
{
    public class OAuthHeaderGeneratorTests
    {

        [Fact()]
        public void ComputedValueTestWhenRequestToken()
        {
            var mockUtilMethods = new Mock<UtilMethods>();
            mockUtilMethods.Setup((utilMethods) => utilMethods.RandomString(It.IsAny<int>())).Returns("JCKNUMB75U");
            mockUtilMethods.SetupGet((utilMethods) => utilMethods.UnixTimeSeconds).Returns(1617356469);
            UtilMethods.Singleton = mockUtilMethods.Object;
            MockUtil.mockAppConfig();
            // ↓postmanで作成した値
            var signatureExpect = "hNjZJBPWF/Toavf2ESTuntujkZg=";
            var headerExpect = "OAuth oauth_callback=\"https%3A%2F%2Flocalhost%3A8000\",oauth_consumer_key=\"ULoMphmQLJ1gVY0q64Vp55UCc\",oauth_nonce=\"JCKNUMB75U\",oauth_signature_method=\"HMAC-SHA1\",oauth_timestamp=\"1617356469\",oauth_version=\"1.0\",oauth_signature=\"hNjZJBPWF%2FToavf2ESTuntujkZg%3D\"";
            var OAuthHeaderGenerator = new OAuthHeaderGenerator(TwitterUrl.REQUEST_TOKEN, WebRequestMethods.Http.Post);
            OAuthHeaderGenerator.SetAcessTokenAndSecret("", "");
            OAuthHeaderGenerator.AddParameter("oauth_callback", "https://localhost:8000");
            Assert.Equal(signatureExpect, OAuthHeaderGenerator.Signature);
            Assert.Equal(headerExpect, OAuthHeaderGenerator.Header);
        }
    }
}