using System;
using System.Collections.Generic;
using System.Text;

namespace K42un0k0SnsDeck.DomainModels.TwitterAccount
{
    public class TwitterAccountCredentials
    {
        public string AccessToken { get; set; }
        public string AccessTokenSecret { get; set; }

        public TwitterAccountCredentials(string accessToken, string accessTokenSecret)
        {
            AccessToken = accessToken;
            AccessTokenSecret = accessTokenSecret;
        }
        public override bool Equals(object obj)
        {
            if (!(obj is TwitterAccountCredentials))
            {
                return false;
            }
            var credentials = (TwitterAccountCredentials)obj;
            return credentials.AccessToken == AccessToken && credentials.AccessTokenSecret == AccessTokenSecret;
        }

    }
}
