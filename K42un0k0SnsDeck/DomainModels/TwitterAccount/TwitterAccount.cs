using System;
using System.Collections.Generic;
using System.Text;

namespace K42un0k0SnsDeck.DomainModels.TwitterAccount
{
    public class TwitterAccount
    {
        public TwitterAccount(long id, TwitterAccountCredentials credentials, string accountName)
        {
            Id = id;
            Credentials = credentials;
            AccountName = accountName;
        }

        public long Id { get; set; }
        public TwitterAccountCredentials Credentials { get; set; }
        public string AccountName { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is TwitterAccount))
            {
                return false;
            }
            var account = (TwitterAccount)obj;
            return account.Id == Id && account.Credentials.Equals(Credentials) && account.AccountName == AccountName;
        }
    }
}
