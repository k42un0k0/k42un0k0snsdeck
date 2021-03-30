using K42un0k0SnsDeck.Models;
using System;

namespace K42un0k0SnsDeck.DomainServices
{
    public interface ITwitterAccountFactory
    {
        TwitterAccount CreateFromRedirectUri(Uri redirectUrl);
    }
}
