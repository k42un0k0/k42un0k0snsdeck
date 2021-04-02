using K42un0k0SnsDeck.Common;
using K42un0k0SnsDeck.Constants;
using K42un0k0SnsDeck.DomainModels.TwitterAccount;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Http;
using Unity;

namespace K42un0k0SnsDeck.Infra.Http
{
    public interface ITwitterClient
    {
        public string GetAccountName(TwitterAccountCredentials credentials);
    }

    public class TwitterClient : ITwitterClient
    {
        [Dependency]
        public HttpClient httpClient;

        public string GetAccountName(TwitterAccountCredentials credentials)
        {
            var oauth = new OAuthHeaderGenerator(TwitterUrl.VERIFY_CREDENTIALS, WebRequestMethods.Http.Get);
            oauth.SetAcessTokenAndSecret("", "");

            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(TwitterUrl.VERIFY_CREDENTIALS),
                Method = HttpMethod.Get,
            };
            request.Headers.Add("Authorization", oauth.Header);

            var json = httpClient.SendAsync(request).Result.Content.ReadAsStringAsync().Result;
            var obj = JObject.Parse(json);
            return obj["name"].ToObject<string>();
        }
    }
}
