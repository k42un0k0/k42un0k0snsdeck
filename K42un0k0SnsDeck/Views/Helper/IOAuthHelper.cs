using K42un0k0SnsDeck.Usecases;
using System;
using System.Threading.Tasks;

namespace K42un0k0SnsDeck.Views.Helper
{

    public interface IOAuthHelper
    {
        public string GetOAuthUrl();

        public CreateAcountWhenOAuthCommand FetchUsecaseCommandFromRedirectUrl(Uri redirectUrl);
    }
}
