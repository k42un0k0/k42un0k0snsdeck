using K42un0k0SnsDeck.Usecases;

namespace K42un0k0SnsDeck.Views.Helper
{

    public interface IOAuthHelper
    {
        public string OAuthUrl();

        public CreateAcountWhenOAuthCommand FetchOAuthCredentialsCommandFromRedirectUrl(string redirectUrl);
    }
}
