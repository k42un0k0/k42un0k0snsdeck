using K42un0k0SnsDeck.DomainModels.TwitterAccount;
using K42un0k0SnsDeck.DomainServices;
using K42un0k0SnsDeck.Infra.Dao.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity;

namespace K42un0k0SnsDeck.Infra.DomainServices
{
    public class TwitterAccountRepository : ITwitterAccountRepository
    {
        [Dependency]
        public ITwitterAccountDao twitterAccountDao;
        public TwitterAccountRepository()
        {
        }
        public void Add(TwitterAccount account)
        {
            twitterAccountDao.Add(account);
        }

        public List<TwitterAccount> FindAll()
        {
            return twitterAccountDao.FindAll().Select((dto) => (TwitterAccount)dto).ToList();
        }
    }
}
