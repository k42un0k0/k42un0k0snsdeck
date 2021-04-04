using K42un0k0SnsDeck.DomainModels.FacebookAccount;
using K42un0k0SnsDeck.DomainServices;
using K42un0k0SnsDeck.Infra.Dao.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace K42un0k0SnsDeck.Infra.DomainServices
{
    public class FacebookAccountRepository : IFacebookAccountRepository
    {
        private readonly Func<IFacebookAccountDao> _getFacebookAccountDao;
        public FacebookAccountRepository(Func<IFacebookAccountDao> getFacebookAccountDao)
        {
            _getFacebookAccountDao = getFacebookAccountDao;
        }
        public void Add(FacebookAccount account)
        {
            _getFacebookAccountDao().Add(account);
        }

        public List<FacebookAccount> FindAll()
        {
            return _getFacebookAccountDao().FindAll().Select((dto) => (FacebookAccount)dto).ToList();
        }
    }
}
