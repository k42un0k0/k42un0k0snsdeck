using K42un0k0SnsDeck.Infra.Dto.Json;
using K42un0k0SnsDeck.Infra.Provider;
using System;
using System.Collections.Generic;

namespace K42un0k0SnsDeck.Infra.Dao.Json
{
    public interface ITwitterAccountDao
    {
        public void Add(TwitterAccountDto dto);
        public List<TwitterAccountDto> FindAll();

    }
    public class TwitterAccountDao : Dao<TwitterAccountDto>, ITwitterAccountDao
    {
        public TwitterAccountDao(Func<IJsonProvider> getJsonProvider) : base(getJsonProvider)
        {
            if (_data == null)
            {
                _data = new List<TwitterAccountDto>();
            }
        }

        // TODO: indexをはるか、作成に制限をつけるか考える
        public void Add(TwitterAccountDto dto)
        {
            var len = _data.Count;
            long id;
            if (len == 0)
            {
                id = 1;
            }
            else
            {
                var last = _data[len - 1];
                id = last.Id + 1;
            }

            if (dto.Id == 0)
            {
                dto.Id = id;
            }
            _data.Add(dto);
        }
        public List<TwitterAccountDto> FindAll()
        {
            return _data;
        }
    }
}
