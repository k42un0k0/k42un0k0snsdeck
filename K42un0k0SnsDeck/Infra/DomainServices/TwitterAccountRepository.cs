using K42un0k0SnsDeck.DomainModels.TwitterAccount;
using K42un0k0SnsDeck.DomainServices;
using K42un0k0SnsDeck.Infra.Dao.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace K42un0k0SnsDeck.Infra.DomainServices
{
    public class TwitterAccountRepository : ITwitterAccountRepository
    {
        private readonly Func<ITwitterAccountDao> _getTwitterAccountDao;
        public TwitterAccountRepository(Func<ITwitterAccountDao> getTwitterAccountDao)
        {
            _getTwitterAccountDao = getTwitterAccountDao;
        }
        public void Add(TwitterAccount account)
        {
            _getTwitterAccountDao().Add(account);
        }

        public List<TwitterAccount> FindAll()
        {
            return _getTwitterAccountDao().FindAll().Select((dto) => (TwitterAccount)dto).ToList();
        }
    }
}
