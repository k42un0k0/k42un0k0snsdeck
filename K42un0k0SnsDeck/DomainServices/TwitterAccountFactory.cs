using K42un0k0SnsDeck.Models;
using System;

namespace K42un0k0SnsDeck.DomainServices
{
    interface TwitterAccountFactory
    {
        TwitterAccount createFromRedirectUri(Uri redirectUrl);
    }
}
