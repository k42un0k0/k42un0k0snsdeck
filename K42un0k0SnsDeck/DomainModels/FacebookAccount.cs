using System;
using System.Collections.Generic;
using System.Text;

namespace K42un0k0SnsDeck.Models
{
    class FacebookAccount
    {
        private long _id;
        private string _accessToken;
        private string _accountName;


        public FacebookAccount(long id, string accessToken, string accountName)
        {
            _id = id;
            _accessToken = accessToken;
            _accountName = accountName;
        }

    }
}
