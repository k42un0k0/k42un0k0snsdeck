using K42un0k0SnsDeck.Common;
using K42un0k0SnsDeck.Constants;
using K42un0k0SnsDeck.DomainModels.TwitterAccount;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using Unity;

namespace K42un0k0SnsDeck.Infra.Http
{
    public interface ITwitterClient
    {
        public Uri GetOAuthUrl();

        public string GetAccountName(TwitterAccountCredentials credentials);
        public TwitterAccountCredentials FetchCredentialsFromRedirectUrl(Uri redirectUrl);
    }

    public class TwitterClient : ITwitterClient
    {
        [Dependency]
        public HttpClient httpClient { get; set; }

        public Uri GetOAuthUrl()
        {
            var request = CreateRequest();
            var response = httpClient.SendAsync(request).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            var oauth_token = ComputeAuthTokenFromContent(content);
            return new Uri($"{TwitterUrl.OAUTH}?oauth_token={oauth_token}");
            //return new Uri("https://twitter.com");
        }

        private HttpRequestMessage CreateRequest()
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

        private string ComputeAuthTokenFromContent(string message)
        {
            // oauth_token=Z6eEdO8MOmk394WozF5oKyuAv855l4Mlqo7hhlSLik&oauth_token_secret=Kd75W4OQfb2oJTV0vzGzeXftVAwgMnEK9MumzYcM&oauth_callback_confirmed=true
            return message.Split("&")[0].Split("=")[1];
        }

        public string GetAccountName(TwitterAccountCredentials credentials)
        {
            var oauth = new OAuthHeaderGenerator(TwitterUrl.VERIFY_CREDENTIALS, WebRequestMethods.Http.Get);
            oauth.SetAcessTokenAndSecret(credentials.AccessToken, credentials.AccessTokenSecret);

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
        /// <summary>
        /// リダイレクトURLをもらいユースケースの引数を返す
        /// </summary>
        /// <param name="redirectUrl">
        /// OAuthでログインした後にユーザーがリダイレクトしたURL
        /// 例）https://yourCallbackUrl.com?oauth_token=NPcudxy0yU5T3tBzho7iCotZ3cnetKwcTIRlX0iwRl0&oauth_verifier=uw7NjWHT6OJ1MpJOXsHfNxoAhPKpgI8BlYDhxEjIBY
        /// </param>
        /// <returns></returns>
        public TwitterAccountCredentials FetchCredentialsFromRedirectUrl(Uri redirectUrl)
        {
            var query = HttpUtility.ParseQueryString(redirectUrl.Query);
            var response = httpClient.PostAsync($"{TwitterUrl.ACCESS_TOKEN}?oauth_consumer_key={AppConfig.Singleton.TwitterApiKey}&oauth_token={query["oauth_token"]}&oauth_verifier={query["oauth_verifier"]}", new StringContent("")).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            return ComputeCommandFromContent(content);
        }
        private TwitterAccountCredentials ComputeCommandFromContent(string message)
        {
            // oauth_token=6253282-eWudHldSbIaelX7swmsiHImEL4KinwaGloHANdrY&oauth_token_secret=2EEfA6BG5ly3sR3XjE0IBSnlQu4ZrUzPiYTmrkVU&user_id=6253282&screen_name=twitterapi
            var kvp = message.Split("&").Select((item) => item.Split("=")).ToList();
            return new TwitterAccountCredentials(kvp[0][1], kvp[1][1]);
        }

    }
}
