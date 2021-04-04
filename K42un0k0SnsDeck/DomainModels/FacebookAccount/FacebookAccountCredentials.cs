namespace K42un0k0SnsDeck.DomainModels.FacebookAccount
{
    public class FacebookAccountCredentials
    {
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public long ExpiresIn { get; set; }


        public FacebookAccountCredentials(string accessToken, string tokenType, long expiresIn)
        {
            AccessToken = accessToken;
            TokenType = tokenType;
            ExpiresIn = expiresIn;
        }
        public override bool Equals(object obj)
        {
            if (!(obj is FacebookAccountCredentials))
            {
                return false;
            }
            var credentials = (FacebookAccountCredentials)obj;
            return credentials.AccessToken == AccessToken && credentials.TokenType == TokenType && credentials.ExpiresIn == ExpiresIn;
        }

    }
}
