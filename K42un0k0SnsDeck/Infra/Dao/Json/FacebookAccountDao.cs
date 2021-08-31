using K42un0k0SnsDeck.Infra.Provider;
using System;
using System.Collections.Generic;

namespace K42un0k0SnsDeck.Infra.Dao.Json
{
    public interface IFacebookAccountDao
    {
        public void Add(FacebookAccountDto dto);
        public List<FacebookAccountDto> FindAll();

    }
    public class FacebookAccountDao : Dao<FacebookAccountDto>, IFacebookAccountDao
    {
        public FacebookAccountDao(Func<IJsonProvider> getJsonProvider) : base(getJsonProvider)
        {
            if (_data == null)
            {
                _data = new List<FacebookAccountDto>();
            }
        }

        // TODO: indexをはるか、作成に制限をつけるか考える
        public void Add(FacebookAccountDto dto)
        {
            _data.Add(dto);
            OnUpdateData();
        }
        public List<FacebookAccountDto> FindAll()
        {
            return _data;
        }
    }
}
