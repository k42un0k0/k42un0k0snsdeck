using K42un0k0SnsDeck.Constants;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace K42un0k0SnsDeck.Common
{
    /// <summary>
    /// oauthのシグネチャの計算とヘッダーを作成するクラス
    /// 詳細は<see href="https://developer.twitter.com/en/docs/authentication/oauth-1-0a/creating-a-signature">こちら</see>
    /// </summary>
    /// 

    public class OAuthHeaderGenerator
    {
        private string HttpMethod { get; set; }
        private string BaseUrl { get; set; }

        private string OAuthNonce = UtilMethods.Singleton.RandomString(10);
        private string OAuthSignatureMethod = "HMAC-SHA1";
        private string OAuthTimestamp { get { return UtilMethods.Singleton.UnixTimeSeconds.ToString(); } }
        private string OAuthCustomerKey = AppConfig.Singleton.TwitterApiKey;
        private string OAuthVersion = "1.0";
        private string AccessTokenSecret { get; set; } = AppConfig.Singleton.TwitterAccessTokenSecret;
        private string AccessToken { get; set; } = AppConfig.Singleton.TwitterAccessToken;

        private SortedDictionary<string, string> parameters = new SortedDictionary<string, string>();


        public OAuthHeaderGenerator(string baseUrl, string httpMethod)
        {
            BaseUrl = baseUrl;
            HttpMethod = httpMethod;
            setMinimumParams();
        }
        private void setMinimumParams()
        {
            parameters.Add("oauth_nonce", OAuthNonce);
            parameters.Add("oauth_consumer_key", OAuthCustomerKey);
            parameters.Add("oauth_signature_method", OAuthSignatureMethod);
            parameters.Add("oauth_timestamp", OAuthTimestamp);
            parameters.Add("oauth_version", OAuthVersion);
            parameters.Add("oauth_token", AppConfig.Singleton.TwitterAccessToken);
        }

        public void AddParameter(string key, string value)
        {
            parameters.Add(key, value);
        }

        public void SetAcessTokenAndSecret(string accessToken, string accessTokenSecret)
        {
            AccessToken = accessToken;
            AccessTokenSecret = accessTokenSecret;
            if (accessToken == "")
            {
                parameters.Remove("oauth_token");
            }
            else
            {
                try
                {
                    parameters.Add("oauth_token", accessToken);
                }
                catch (ArgumentException)
                {
                    parameters["oauth_token"] = accessToken;
                }
            }
        }

        private string ParameterString
        {
            get
            {
                var parameterString = "";
                foreach (KeyValuePair<string, string> kvp in parameters)
                {
                    parameterString = parameterString + (parameterString == "" ? "" : "&") + $"{Uri.EscapeDataString(kvp.Key)}={Uri.EscapeDataString(kvp.Value)}";
                }
                return parameterString;
            }
        }

        private byte[] BaseString
        {
            get
            {
                return Encoding.UTF8.GetBytes($"{HttpMethod}&{Uri.EscapeDataString(BaseUrl)}&{Uri.EscapeDataString(ParameterString)}");
            }
        }
        private byte[] SigningKey
        {
            get
            {
                return Encoding.UTF8.GetBytes($"{Uri.EscapeDataString(AppConfig.Singleton.TwitterApiSecretKey)}&{Uri.EscapeDataString(AccessTokenSecret)}");
            }
        }
        public string Signature
        {
            get
            {
                var sha1 = new HMACSHA1(SigningKey);
                return Convert.ToBase64String(sha1.ComputeHash(BaseString));
            }
        }

        public string Header
        {
            get
            {
                var header = "OAuth ";
                foreach (KeyValuePair<string, string> kvp in parameters)
                {
                    header = header + (header == "OAuth " ? "" : ",") + $"{Uri.EscapeDataString(kvp.Key)}=\"{Uri.EscapeDataString(kvp.Value)}\"";
                }
                header = header + $",oauth_signature=\"{Uri.EscapeDataString(Signature)}\"";
                return header;
            }
        }

    }
}
