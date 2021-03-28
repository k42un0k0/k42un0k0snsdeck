using K42un0k0SnsDeck.Models;
using System.Collections.Generic;

namespace K42un0k0SnsDeck.DomainServices
{
    interface FacebookAccountRepository
    {
        void Add(FacebookAccount account);
        List<FacebookAccount> FindAll();
    }
}
