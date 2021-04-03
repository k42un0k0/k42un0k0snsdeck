namespace K42un0k0SnsDeck.DomainModels.FacebookAccount
{
    public class FacebookAccountCredentials
    {
        public string AccessToken { get; set; }
        public string AccessTokenSecret { get; set; }

        public FacebookAccountCredentials(string accessToken, string accessTokenSecret)
        {
            AccessToken = accessToken;
            AccessTokenSecret = accessTokenSecret;
        }
        public override bool Equals(object obj)
        {
            if (!(obj is FacebookAccountCredentials))
            {
                return false;
            }
            var credentials = (FacebookAccountCredentials)obj;
            return credentials.AccessToken == AccessToken && credentials.AccessTokenSecret == AccessTokenSecret;
        }

    }
}
