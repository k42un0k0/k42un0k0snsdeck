using K42un0k0SnsDeck.DomainServices;
using K42un0k0SnsDeck.Infra.Http;
using K42un0k0SnsDeck.Models;
using System;

namespace K42un0k0SnsDeck.Infra.DomainServices
{
    public class TwitterAccountFactory : ITwitterAccountFactory
    {
        private readonly string ACCESS_TOKEN_KEY = "access_token";
        private readonly Func<ITwitterClient> _getTwitterClient;
        public TwitterAccountFactory(Func<ITwitterClient> getTwitterClient)
        {
            _getTwitterClient = getTwitterClient;
        }
        public TwitterAccount CreateFromRedirectUri(Uri redirectUrl)
        {
            var client = _getTwitterClient();
            var accountName = client.GetAccountName();
            var sQuery = redirectUrl.Query;
            var query = System.Web.HttpUtility.ParseQueryString(sQuery);
            return new TwitterAccount(0,query.Get(ACCESS_TOKEN_KEY), accountName);
        }
    }
}
