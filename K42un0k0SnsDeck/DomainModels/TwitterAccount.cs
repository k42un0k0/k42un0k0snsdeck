using System;
using System.Collections.Generic;
using System.Text;

namespace K42un0k0SnsDeck.Models
{
    public class TwitterAccount
    {
        public TwitterAccount(long id, string accessToken, string accountName)
        {
            Id = id;
            AccessToken = accessToken;
            AccountName = accountName;
        }

        public long Id { get; set; }
        public string AccessToken { get; set; }
        public string AccountName { get; set; }

    }
}
