using K42un0k0SnsDeck.DomainModels.FacebookAccount;
using K42un0k0SnsDeck.DomainModels.TwitterAccount;
using K42un0k0SnsDeck.DomainServices;
using Prism.Mvvm;
using System.Collections.Generic;
using Unity;

namespace K42un0k0SnsDeck.ViewModels
{
    public class AccountListWindowViewModel : BindableBase
    {
        [Dependency]
        public ITwitterAccountRepository TwitterAccountRepository;
        [Dependency]
        public IFacebookAccountRepository FacebookAccountRepository;

        private List<TwitterAccount> _twitterAccountList;
        public List<TwitterAccount> TwitterAccountList { get { return _twitterAccountList; } private set { SetProperty(ref _twitterAccountList, value); } }

        private List<FacebookAccount> _facebookAccountList;
        public List<FacebookAccount> FacebookAccountList { get { return _facebookAccountList; } private set { SetProperty(ref _facebookAccountList, value); } }

        public void Load()
        {
            TwitterAccountList = TwitterAccountRepository.FindAll();
            FacebookAccountList = FacebookAccountRepository.FindAll();
        }

    }
}
