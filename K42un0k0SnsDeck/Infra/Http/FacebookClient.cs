using K42un0k0SnsDeck.Common;
using K42un0k0SnsDeck.Constants;
using K42un0k0SnsDeck.DomainModels.FacebookAccount;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Http;
using Unity;

namespace K42un0k0SnsDeck.Infra.Http
{
    public interface IFacebookClient
    {
        public Uri GetOAuthUrl();

        public string GetAccountName(FacebookAccountCredentials credentials);

        public FacebookAccountCredentials FetchCredentialsFromRedirectUrl(Uri redirectUrl);
    }

    public class FacebookClient : IFacebookClient
    {
        [Dependency]
        public HttpClient httpClient;
        public Uri GetOAuthUrl()
        {
            return new Uri($"{FacebookUrl.OAUTH}?client_id={AppConfig.Singleton.FacebookAppId}&redirect_uri={AppConfig.Singleton.FacebookCallbackUrl}");
        }

        public string GetAccountName(FacebookAccountCredentials credentials)
        {
            throw new NotImplementedException();
        }

        public FacebookAccountCredentials FetchCredentialsFromRedirectUrl(Uri redirectUrl)
        {
            throw new NotImplementedException();
        }
    }
}
