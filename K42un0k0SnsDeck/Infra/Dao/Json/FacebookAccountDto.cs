using K42un0k0SnsDeck.DomainModels.FacebookAccount;
using System.Collections.Generic;
using System.Linq;

namespace K42un0k0SnsDeck.Infra.Dao.Json
{
    public class FacebookAccountDto
    {

        public FacebookAccountDto(string id, string accessToken, string tokenType, long expiresIn, string accountName)
        {
            Id = id;
            AccessToken = accessToken;
            TokenType = tokenType;
            ExpiresIn = expiresIn;
            AccountName = accountName;
        }
        public string Id { get; set; }
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public long ExpiresIn { get; set; }
        public string AccountName { get; set; }

        public static implicit operator FacebookAccountDto(FacebookAccount model)
        {
            return new FacebookAccountDto(model.Id, model.Credentials.AccessToken, model.Credentials.TokenType, model.Credentials.ExpiresIn, model.AccountName);
        }
        public static implicit operator FacebookAccount(FacebookAccountDto dto)
        {
            return new FacebookAccount(dto.Id, new FacebookAccountCredentials(dto.AccessToken, dto.TokenType, dto.ExpiresIn), dto.AccountName);
        }
    }
}
