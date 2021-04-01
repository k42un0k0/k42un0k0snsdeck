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

        public override bool Equals(object obj)
        {
            if (!(obj is TwitterAccount))
            {
                return false;
            }
            var account = (TwitterAccount)obj;
            return account.Id == Id && account.AccessToken == AccessToken && account.AccountName == AccountName;
        }
    }
}
