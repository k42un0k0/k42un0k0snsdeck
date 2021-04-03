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
            var credentials = new TwitterAccountCredentials("accesstoken", "accesstokensecret");
            Assert.Equal("hello", twitterClient.GetAccountName(credentials));
        }
        [Fact()]
        public void OAuthUrlTest()
        {
            MockUtil.mockAppConfig();
            var httpClient = MockUtil.mockResponseText(@"oauth_token=Z6eEdO8MOmk394WozF5oKyuAv855l4Mlqo7hhlSLik&oauth_token_secret=Kd75W4OQfb2oJTV0vzGzeXftVAwgMnEK9MumzYcM&oauth_callback_confirmed=true");
            var twitterClient = new TwitterClient();
            twitterClient.httpClient = httpClient;

            Assert.Equal(new Uri("https://api.twitter.com/oauth/authorize?oauth_token=Z6eEdO8MOmk394WozF5oKyuAv855l4Mlqo7hhlSLik"), twitterClient.GetOAuthUrl());
        }

        [Fact()]
        public void FetchUsecaseCommandFromRedirectUrlTest()
        {
            var httpClient = MockUtil.mockResponseText(@"oauth_token=6253282-eWudHldSbIaelX7swmsiHImEL4KinwaGloHANdrY&oauth_token_secret=2EEfA6BG5ly3sR3XjE0IBSnlQu4ZrUzPiYTmrkVU&user_id=6253282&screen_name=twitterapi");
            var twitterOAuthHelper = new TwitterClient();
            twitterOAuthHelper.httpClient = httpClient;
            var redirectUrl = new Uri("https://yourCallbackUrl.com?oauth_token=NPcudxy0yU5T3tBzho7iCotZ3cnetKwcTIRlX0iwRl0&oauth_verifier=uw7NjWHT6OJ1MpJOXsHfNxoAhPKpgI8BlYDhxEjIBY");
            var command = twitterOAuthHelper.FetchCredentialsFromRedirectUrl(redirectUrl);

            Assert.Equal("6253282-eWudHldSbIaelX7swmsiHImEL4KinwaGloHANdrY", command.AccessToken);
            Assert.Equal("2EEfA6BG5ly3sR3XjE0IBSnlQu4ZrUzPiYTmrkVU", command.AccessTokenSecret);
        }

    }
}