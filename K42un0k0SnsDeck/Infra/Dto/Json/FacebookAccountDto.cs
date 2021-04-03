using K42un0k0SnsDeck.DomainModels.FacebookAccount;
using System.Collections.Generic;
using System.Linq;

namespace K42un0k0SnsDeck.Infra.Dto.Json
{
    public class FacebookAccountDto
    {

        public FacebookAccountDto(long id, string accessToken, string accessTokenSecret, string accountName)
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

        public static implicit operator FacebookAccountDto(FacebookAccount model)
        {
            return new FacebookAccountDto(model.Id, model.Credentials.AccessToken, model.Credentials.AccessTokenSecret, model.AccountName);
        }
        public static implicit operator FacebookAccount(FacebookAccountDto dto)
        {
            return new FacebookAccount(dto.Id, new FacebookAccountCredentials(dto.AccessToken, dto.AccessTokenSecret), dto.AccountName);
        }
    }
}
