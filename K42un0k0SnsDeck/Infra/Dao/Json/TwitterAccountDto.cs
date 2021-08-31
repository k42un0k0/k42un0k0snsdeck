using K42un0k0SnsDeck.DomainModels.TwitterAccount;
using System.Collections.Generic;
using System.Linq;

namespace K42un0k0SnsDeck.Infra.Dao.Json
{
    public class TwitterAccountDto
    {

        public TwitterAccountDto(long id, string accessToken, string accessTokenSecret, string accountName)
        {
            Id = id;
            AccessToken = accessToken;
            AccessTokenSecret = accessTokenSecret;
            AccountName = accountName;
        }
        public long Id { get; set; }
        public string AccessToken { get; set; }
        public string AccessTokenSecret { get; set; }
        public string AccountName { get; set; }

        public static implicit operator TwitterAccountDto(TwitterAccount model)
        {
            return new TwitterAccountDto(model.Id, model.Credentials.AccessToken, model.Credentials.AccessTokenSecret, model.AccountName);
        }
        public static implicit operator TwitterAccount(TwitterAccountDto dto)
        {
            return new TwitterAccount(dto.Id, new TwitterAccountCredentials(dto.AccessToken, dto.AccessTokenSecret), dto.AccountName);
        }
    }
}
