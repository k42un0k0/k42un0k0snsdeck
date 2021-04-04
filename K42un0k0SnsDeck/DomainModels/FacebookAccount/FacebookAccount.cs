namespace K42un0k0SnsDeck.DomainModels.FacebookAccount
{
    public class FacebookAccount
    {
        public FacebookAccount(string id, FacebookAccountCredentials credentials, string accountName)
        {
            Id = id;
            Credentials = credentials;
            AccountName = accountName;
        }

        public string Id { get; set; }
        public FacebookAccountCredentials Credentials { get; set; }
        public string AccountName { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is FacebookAccount))
            {
                return false;
            }
            var account = (FacebookAccount)obj;
            return account.Id == Id && account.Credentials.Equals(Credentials) && account.AccountName == AccountName;
        }
    }
}
