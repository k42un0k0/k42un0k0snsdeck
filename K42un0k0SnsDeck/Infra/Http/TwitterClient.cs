using K42un0k0SnsDeck.DomainModels.TwitterAccount;
using System;

namespace K42un0k0SnsDeck.Infra.Common
{
    public interface ITwitterClient
    {
        public string GetAccountName();
    }

    public class TwitterClient: ITwitterClient
    {
        private TwitterAccountCredentials Creadentials { get; set; }
        public TwitterClient(TwitterAccountCredentials credentials)
        {
            Creadentials = credentials;
        }

        public string GetAccountName()
        {
            throw new NotImplementedException();
        }
    }
}
