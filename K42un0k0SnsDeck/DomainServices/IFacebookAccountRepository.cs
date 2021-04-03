using K42un0k0SnsDeck.DomainModels.FacebookAccount;
using System.Collections.Generic;

namespace K42un0k0SnsDeck.DomainServices
{
    public interface IFacebookAccountRepository
    {
        void Add(FacebookAccount account);
        List<FacebookAccount> FindAll();
    }
}
