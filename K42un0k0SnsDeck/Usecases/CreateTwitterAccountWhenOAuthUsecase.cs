using K42un0k0SnsDeck.DomainModels.TwitterAccount;
using K42un0k0SnsDeck.DomainServices;
using K42un0k0SnsDeck.Infra.Http;
using Unity;

namespace K42un0k0SnsDeck.Usecases
{
    public class CreateTwitterAccountWhenOAuthUsecase : ICreateAccountWhenOAuthUsecase
    {
        [Dependency]
        public ITwitterAccountRepository twitterAccountRepository { get; set; }
        [Dependency]
        public ITwitterClient twitterClient { get; set; }

        public void exec(CreateAcountWhenOAuthCommand command)
        {

            var credentials = new TwitterAccountCredentials(command.AccessToken, command.AccessTokenSecret);
            var accountName = twitterClient.GetAccountName(credentials);
            var account = new TwitterAccount(0, credentials, accountName);
            twitterAccountRepository.Add(account);
        }
    }
}
