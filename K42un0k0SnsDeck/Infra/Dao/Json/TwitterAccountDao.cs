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
            _data.Add(dto);
            OnUpdateData();
        }

        List<TwitterAccountDto> ITwitterAccountDao.FindAll()
        {
            return _data;
        }
    }
}
