using K42un0k0SnsDeck.Common;
using K42un0k0SnsDeck.Constants;
using K42un0k0SnsDeck.Usecases;
using System;
using System.Net;
using Unity;
using Windows.Web.Http;

namespace K42un0k0SnsDeck.Views.Helper
{
    public class TwitterOAuthHelper : IOAuthHelper

    {
        [Dependency]
        public HttpClient client { get; set; }

        public string OAuthUrl()
        {
            var oauth = new OAuthHeaderGenerator(TwitterUrl.REQUEST_TOKEN, WebRequestMethods.Http.Post);
            oauth.SetAcessTokenAndSecret("", "");
            oauth.AddParameter("oauth_callback", AppConfig.Singleton.TwitterCallbackUrl);

            System.Diagnostics.Debug.Print(oauth.Header);
            var oauth_token = "";
            return $"https://api.twitter.com/oauth/authorize?oauth_token={oauth_token}";
        }

        public CreateAcountWhenOAuthCommand FetchOAuthCredentialsCommandFromRedirectUrl(string redirectUrl)
        {
            throw new NotImplementedException();
        }
    }
}
