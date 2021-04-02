namespace K42un0k0SnsDeck.Usecases
{
    public class CreateAcountWhenOAuthCommand
    {
        public string AccessToken { get; set; }
        public string AccessTokenSecret { get; set; }

        public CreateAcountWhenOAuthCommand(string accessToken, string accessTokenSecret)
        {
            AccessToken = accessToken;
            AccessTokenSecret = accessTokenSecret;
        }
    }
}
