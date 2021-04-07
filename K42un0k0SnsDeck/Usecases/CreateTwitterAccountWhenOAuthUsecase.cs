using K42un0k0SnsDeck.DomainModels.TwitterAccount;
using K42un0k0SnsDeck.DomainServices;
using K42un0k0SnsDeck.Infra.Http;
using System;
using Unity;

namespace K42un0k0SnsDeck.Usecases
{
    public class CreateTwitterAccountWhenOAuthUsecase : ICreateAccountWhenOAuthUsecase
    {
        [Dependency]
        public ITwitterAccountRepository twitterAccountRepository { get; set; }
        [Dependency]
        public ITwitterClient twitterClient { get; set; }

        public void exec(Uri redirectUrl)
        {
            var credentials = twitterClient.FetchCredentialsFromRedirectUrl(redirectUrl);
            var id = twitterClient.GetId(credentials);
            var accountName = twitterClient.GetAccountName(credentials);
            var account = new TwitterAccount(id, credentials, accountName);
            twitterAccountRepository.Add(account);
        }
    }
}
