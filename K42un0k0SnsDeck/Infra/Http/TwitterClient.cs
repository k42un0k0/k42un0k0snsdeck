using K42un0k0SnsDeck.Common;
using K42un0k0SnsDeck.Infra.Http.Common;
using System;
using System.Net;
using Unity;
using Windows.Web.Http;

namespace K42un0k0SnsDeck.Infra.Http
{
    public interface ITwitterClient
    {
        void ConfigureFromRedirectUrl(Uri redirectUrl);
        string GetAccountName();
        string GetIconPath();
    }

    public class TwitterClient : ITwitterClient
    {
        [Dependency]
        public HttpClient client { get; set; }

        public string RequestAuthorizationUrl()
        {
            var oauth = new OAuthValues(TwitterUrl.REQUEST_TOKEN, WebRequestMethods.Http.Post);
            oauth.SetAcessTokenAndSecret("", "");
            oauth.AddParameter("oauth_callback", AppConfig.Singleton.TwitterCallbackUrl);

            System.Diagnostics.Debug.Print(oauth.Header);
            var oauth_token = "";
            return $"https://api.twitter.com/oauth/authorize?oauth_token={oauth_token}";

        }

        public void ConfigureFromRedirectUrl(Uri redirectUrl)
        {
            throw new NotImplementedException();
        }

        public string GetAccountName()
        {
            throw new NotImplementedException();
        }
        public string GetIconPath()
        {
            throw new NotImplementedException();
        }
    }
}
