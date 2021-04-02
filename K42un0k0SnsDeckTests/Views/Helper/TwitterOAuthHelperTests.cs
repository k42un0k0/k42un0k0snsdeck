using Xunit;
using System;
using Moq;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using Moq.Protected;
using System.Threading;
using K42un0k0SnsDeckTests;

namespace K42un0k0SnsDeck.Views.Helper.Tests
{
    public class TwitterOAuthHelperTests
    {
        [Fact()]
        public void OAuthUrlTest()
        {
            MockUtil.mockAppConfig();
            var httpClient = MockUtil.mockResponseText(@"oauth_token=Z6eEdO8MOmk394WozF5oKyuAv855l4Mlqo7hhlSLik&oauth_token_secret=Kd75W4OQfb2oJTV0vzGzeXftVAwgMnEK9MumzYcM&oauth_callback_confirmed=true");
            var twitterOAuthHelper = new TwitterOAuthHelper();
            twitterOAuthHelper.client = httpClient;

            Assert.Equal("https://api.twitter.com/oauth/authorize?oauth_token=Z6eEdO8MOmk394WozF5oKyuAv855l4Mlqo7hhlSLik", twitterOAuthHelper.GetOAuthUrl());
        }

        [Fact()]
        public void FetchUsecaseCommandFromRedirectUrlTest()
        {
            var httpClient = MockUtil.mockResponseText(@"oauth_token=6253282-eWudHldSbIaelX7swmsiHImEL4KinwaGloHANdrY&oauth_token_secret=2EEfA6BG5ly3sR3XjE0IBSnlQu4ZrUzPiYTmrkVU&user_id=6253282&screen_name=twitterapi");
                var twitterOAuthHelper = new TwitterOAuthHelper();
            twitterOAuthHelper.client = httpClient;
            var redirectUrl = new Uri("https://yourCallbackUrl.com?oauth_token=NPcudxy0yU5T3tBzho7iCotZ3cnetKwcTIRlX0iwRl0&oauth_verifier=uw7NjWHT6OJ1MpJOXsHfNxoAhPKpgI8BlYDhxEjIBY");
            var command = twitterOAuthHelper.FetchUsecaseCommandFromRedirectUrl(redirectUrl);

            Assert.Equal("6253282-eWudHldSbIaelX7swmsiHImEL4KinwaGloHANdrY", command.AccessToken);
            Assert.Equal("2EEfA6BG5ly3sR3XjE0IBSnlQu4ZrUzPiYTmrkVU", command.AccessTokenSecret);
        }
    }
}