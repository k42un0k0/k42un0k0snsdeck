using K42un0k0SnsDeck.DomainServices;
using K42un0k0SnsDeck.Infra.HttpClient;
using K42un0k0SnsDeck.Models;
using System;

namespace K42un0k0SnsDeck.Infra.DomainServices
{
    public class TwitterAccountFactoryImpl : TwitterAccountFactory
    {
        private readonly Func<ITwitterClient> _getTwitterClient;
        public TwitterAccountFactoryImpl(Func<ITwitterClient> getTwitterClient)
        {
            _getTwitterClient = getTwitterClient;
        }
        public TwitterAccount CreateFromRedirectUri(Uri redirectUrl)
        {
            var client = _getTwitterClient();
            var accountName = client.GetAccountName();
            var accessToken = redirectUrl.ToString();
            return new TwitterAccount(0, accessToken, accountName);
        }
    }
}
