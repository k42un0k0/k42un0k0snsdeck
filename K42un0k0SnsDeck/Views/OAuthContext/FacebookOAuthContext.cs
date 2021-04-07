using K42un0k0SnsDeck.Constants;
using K42un0k0SnsDeck.Infra.Http;
using K42un0k0SnsDeck.Usecases;
using System;
using Unity;

namespace K42un0k0SnsDeck.Views.OAuthContext
{
    class FacebookOAuthContext : IOAuthContext
    {
        [Dependency]
        public CreateFacebookAccountWhenOAuthUsecase usecase;
        public Uri OAuthUrl => new Uri($"{FacebookUrl.OAUTH}?client_id={AppConfig.Singleton.FacebookAppId}&redirect_uri={AppConfig.Singleton.FacebookCallbackUrl}");

        public ICreateAccountWhenOAuthUsecase Usecase => usecase;

        public string CallbackUrl => AppConfig.Singleton.FacebookCallbackUrl;
    }
}
