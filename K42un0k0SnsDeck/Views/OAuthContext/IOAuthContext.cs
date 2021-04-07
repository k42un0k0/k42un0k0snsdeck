using K42un0k0SnsDeck.Usecases;
using System;

namespace K42un0k0SnsDeck.Views.OAuthContext
{
    public interface IOAuthContext
    {
        public Uri OAuthUrl { get; }
        public ICreateAccountWhenOAuthUsecase Usecase { get; }
        public string CallbackUrl { get; }
    }
}
