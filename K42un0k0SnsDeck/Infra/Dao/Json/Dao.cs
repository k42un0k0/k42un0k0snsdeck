using K42un0k0SnsDeck.Infra.Provider;
using System;
using System.Collections.Generic;

namespace K42un0k0SnsDeck.Infra.Dao.Json
{
    public class Dao<Dto>
    {
        private string JSON_KEY { get { return GetType().Name; } }
        protected readonly Func<IJsonProvider> _getJsonProvider;
        protected List<Dto> _data;
        public Dao(Func<IJsonProvider> getJsonProvider)
        {
            _getJsonProvider = getJsonProvider;
            var jsonProvider = _getJsonProvider();
            _data = jsonProvider.Restore(JSON_KEY,new List<Dto>());
        }
        protected void OnUpdateData()
        {
            _getJsonProvider().Store(JSON_KEY, _data);
        }


    }
}
