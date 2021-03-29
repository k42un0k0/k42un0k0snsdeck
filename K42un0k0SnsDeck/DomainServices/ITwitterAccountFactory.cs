using K42un0k0SnsDeck.Models;
using System;

namespace K42un0k0SnsDeck.DomainServices
{
    interface ITwitterAccountFactory
    {
        TwitterAccount CreateFromRedirectUri(Uri redirectUrl);
    }
}
