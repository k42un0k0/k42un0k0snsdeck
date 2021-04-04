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
            var userId = facebookClient.GetUserId(credentials);
            var accountName = facebookClient.GetAccountName(userId, credentials.AccessToken);
            var account = new FacebookAccount(userId, credentials, accountName);
            facebookAccountRepository.Add(account);
        }
    }
}
