using System;
using K42un0k0SnsDeck.Views;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;

namespace K42un0k0SnsDeck.ViewModels
{
    class MainWindowViewModel : BindableBase
    {

        private Func<IContainerProvider> _getContainer;
        public MainWindowViewModel(Func<IContainerProvider> getContainer)
        {
            _greeting = "こんにちは";
            _getContainer = getContainer;
        }

        private string _greeting;
        public string Greeting
        {
            get { return _greeting; }
            set { SetProperty(ref _greeting, value); }
        }

        private DelegateCommand _exchangeGreetingCommand = null;

        public DelegateCommand ExchangeGreetingCommand => _exchangeGreetingCommand ?? (_exchangeGreetingCommand = new DelegateCommand(OnExchangeGreetingCommand));

        private void OnExchangeGreetingCommand()
        {
            Greeting = Greeting == "こんにちは" ? "こんばんわ" : "こんにちは";
        }

        private DelegateCommand _openAccountListWindow = null;

        public DelegateCommand OpenAccountListWindow => _openAccountListWindow ?? (_openAccountListWindow = new DelegateCommand(OnOpenAccountListWindow));

        private void OnOpenAccountListWindow()
        {
            var w = _getContainer().Resolve<AccountListWindow>();
            w.Show(); 
        }
    }
}
