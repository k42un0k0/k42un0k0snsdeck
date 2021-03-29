using K42un0k0SnsDeck.Infra.Dto.Json;
using K42un0k0SnsDeck.Infra.Provider;
using K42un0k0SnsDeck.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace K42un0k0SnsDeck.Infra.Dao.Json
{
    public class TwitterAccountDao : Dao<TwitterAccountDto>
    {
        public TwitterAccountDao(Func<IJsonProvider> getJsonProvider) : base(getJsonProvider)
        {
        }

        // TODO: indexをはるか、作成に制限をつけるか考える
        public void Add(TwitterAccountDto dto)
        {
            var len = _data.Count;
            var last = _data[len - 1];
            var id = last.Id + 1;
            if (dto.Id == 0)
            {
                throw new NotImplementedException();
            }
            _data.Add(dto);
        }
        public List<TwitterAccountDto> FindAll()
        {
            return _data;
        }
    }
}
