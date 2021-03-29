﻿using K42un0k0SnsDeck.Models;
using System.Collections.Generic;

namespace K42un0k0SnsDeck.DomainServices
{
    interface ITwitterAccountRepository
    {
        void Add(TwitterAccount account);
        List<TwitterAccount> FindAll();
    }
}