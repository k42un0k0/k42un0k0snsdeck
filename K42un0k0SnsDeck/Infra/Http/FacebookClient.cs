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
            var oauth = new OAuthHeaderGenerator(FacebookUrl.VERIFY_CREDENTIALS, WebRequestMethods.Http.Get);
            oauth.SetAcessTokenAndSecret("", "");

            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(FacebookUrl.VERIFY_CREDENTIALS),
                Method = HttpMethod.Get,
            };
            request.Headers.Add("Authorization", oauth.Header);

            var json = httpClient.SendAsync(request).Result.Content.ReadAsStringAsync().Result;
            var obj = JObject.Parse(json);
            return obj["name"].ToObject<string>();
        }

        public FacebookAccountCredentials FetchCredentialsFromRedirectUrl(Uri redirectUrl)
        {
            throw new NotImplementedException();
        }
    }
}
