using K42un0k0SnsDeck.DomainModels.FacebookAccount;
using K42un0k0SnsDeck.DomainServices;
using K42un0k0SnsDeck.Infra.Dao.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity;

namespace K42un0k0SnsDeck.Infra.DomainServices
{
    public class FacebookAccountRepository : IFacebookAccountRepository
    {
        [Dependency]
        public IFacebookAccountDao facebookAccountDao;
        public FacebookAccountRepository()
        {
        }
        public void Add(FacebookAccount account)
        {
            facebookAccountDao.Add(account);
        }

        public List<FacebookAccount> FindAll()
        {
            return facebookAccountDao.FindAll().Select((dto) => (FacebookAccount)dto).ToList();
        }
    }
}
