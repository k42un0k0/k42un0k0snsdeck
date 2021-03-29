using K42un0k0SnsDeck.Models;
using System.Collections.Generic;
using System.Linq;

namespace K42un0k0SnsDeck.Infra.Dto.Json
{
    public class TwitterAccountDto
    {

        public TwitterAccountDto(long id, string accessToken, string accountName)
        {
            Id = id;
            AccessToken = accessToken;
            AccountName = accountName;
        }
        public long Id { get; set; }
        public string AccessToken { get; set; }
        public string AccountName { get; set; }

        public static implicit operator TwitterAccountDto(TwitterAccount model)
        {
            return new TwitterAccountDto(model.Id, model.AccessToken, model.AccountName);
        }
        public static implicit operator TwitterAccount(TwitterAccountDto dto)
        {
            return new TwitterAccount(dto.Id, dto.AccessToken, dto.AccountName);
        }
    }
}
