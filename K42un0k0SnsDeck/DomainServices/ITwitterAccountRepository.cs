using K42un0k0SnsDeck.DomainModels.TwitterAccount;
using System.Collections.Generic;

namespace K42un0k0SnsDeck.DomainServices
{
    public interface ITwitterAccountRepository
    {
        void Add(TwitterAccount account);
        List<TwitterAccount> FindAll();
    }
}
