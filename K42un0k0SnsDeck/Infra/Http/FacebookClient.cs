using K42un0k0SnsDeck.Constants;
using K42un0k0SnsDeck.DomainModels.FacebookAccount;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Web;
using Unity;

namespace K42un0k0SnsDeck.Infra.Http
{
    public interface IFacebookClient
    {
        public FacebookAccountCredentials FetchCredentialsFromRedirectUrl(Uri redirectUrl);
        public string GetUserId(FacebookAccountCredentials credentials);
        public string GetAccountName(string userId, string accessToken);
    }

    public class FacebookClient : IFacebookClient
    {
        [Dependency]
        public HttpClient httpClient;

        public string GetAccountName(string userId, string accessToken)
        {
            var url = new Uri($"{FacebookUrl.GRAPH_ROOT}/{userId}?access_token={accessToken}&fields=name");
            var response = httpClient.GetAsync(url).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            var json = JObject.Parse(content);
            return json["name"].ToObject<string>();
        }

        public FacebookAccountCredentials FetchCredentialsFromRedirectUrl(Uri redirectUrl)
        {
            var code = HttpUtility.ParseQueryString(redirectUrl.Query)["code"];
            var url = new Uri($"{FacebookUrl.ACCESS_TOKEN}?client_id={AppConfig.Singleton.FacebookAppId}&redirect_uri={AppConfig.Singleton.FacebookCallbackUrl}&client_secret={AppConfig.Singleton.FacebookAppSecret}&code={code}");
            var response = httpClient.GetAsync(url).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            var json = JObject.Parse(content);
            return new FacebookAccountCredentials(json["access_token"].ToObject<string>(), json["token_type"].ToObject<string>(), json["expires_in"].ToObject<long>());
        }

        public string GetUserId(FacebookAccountCredentials credentials)
        {
            var url = new Uri($"{FacebookUrl.DEBUG_TOKEN}?access_token={AppConfig.Singleton.FacebookAppId}|{AppConfig.Singleton.FacebookAppSecret}&input_token={credentials.AccessToken }");
            var response = httpClient.GetAsync(url).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            var json = JObject.Parse(content);
            return json["data"]["user_id"].ToObject<string>();
        }
    }
}
