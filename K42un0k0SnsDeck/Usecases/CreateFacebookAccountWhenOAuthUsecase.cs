using K42un0k0SnsDeck.DomainModels.FacebookAccount;
using K42un0k0SnsDeck.DomainServices;
using K42un0k0SnsDeck.Infra.Http;
using System;
using Unity;

namespace K42un0k0SnsDeck.Usecases
{
    public class CreateFacebookAccountWhenOAuthUsecase : ICreateAccountWhenOAuthUsecase
    {
        [Dependency]
        public IFacebookAccountRepository facebookAccountRepository { get; set; }
        [Dependency]
        public IFacebookClient facebookClient { get; set; }

        public void exec(Uri redirectUrl)
        {
            var credentials = facebookClient.FetchCredentialsFromRedirectUrl(redirectUrl);
            var accountName = facebookClient.GetAccountName(credentials);
            var account = new FacebookAccount(0, credentials, accountName);
            facebookAccountRepository.Add(account);
        }
    }
}
