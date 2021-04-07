using K42un0k0SnsDeck.Constants;
using K42un0k0SnsDeck.Infra.Http;
using K42un0k0SnsDeck.Usecases;
using System;
using Unity;

namespace K42un0k0SnsDeck.Views.OAuthContext
{
    public class TwitterOAuthContext : IOAuthContext
    {
        [Dependency]
        public ITwitterClient twitterClient;
        [Dependency]
        public CreateTwitterAccountWhenOAuthUsecase usecase;
        public Uri OAuthUrl => twitterClient.GetOAuthUrl();

        public ICreateAccountWhenOAuthUsecase Usecase => usecase;

        public string CallbackUrl => AppConfig.Singleton.TwitterCallbackUrl;
    }
}
