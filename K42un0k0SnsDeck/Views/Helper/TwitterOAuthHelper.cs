using K42un0k0SnsDeck.Common;
using K42un0k0SnsDeck.Constants;
using K42un0k0SnsDeck.Usecases;
using System;
using System.Net;
using System.Net.Http;
using Unity;

namespace K42un0k0SnsDeck.Views.Helper
{
    public class TwitterOAuthHelper : IOAuthHelper

    {
        [Dependency]
        public HttpClient client { get; set; }

        public string OAuthUrl()
        {
            var request = createRequest();
            var response = client.SendAsync(request).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            var oauth_token = computeAuthTokenFromContent(content);
            return $"https://api.twitter.com/oauth/authorize?oauth_token={oauth_token}";
        }

        private HttpRequestMessage createRequest()
        {
            var oauth = new OAuthHeaderGenerator(TwitterUrl.REQUEST_TOKEN, WebRequestMethods.Http.Post);
            oauth.SetAcessTokenAndSecret("", "");
            oauth.AddParameter("oauth_callback", AppConfig.Singleton.TwitterCallbackUrl);

            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(TwitterUrl.REQUEST_TOKEN),
                Method = HttpMethod.Post,
            };
            request.Headers.Add("Authorization", oauth.Header);
            return request;
        }

        private string computeAuthTokenFromContent(string message)
        {
            // oauth_token=Z6eEdO8MOmk394WozF5oKyuAv855l4Mlqo7hhlSLik&oauth_token_secret=Kd75W4OQfb2oJTV0vzGzeXftVAwgMnEK9MumzYcM&oauth_callback_confirmed=true
            return message.Split("&")[0].Split("=")[1];
        }

        public CreateAcountWhenOAuthCommand FetchUsecaseCommandFromRedirectUrl(string redirectUrl)
        {
            throw new NotImplementedException();
        }
    }
}
