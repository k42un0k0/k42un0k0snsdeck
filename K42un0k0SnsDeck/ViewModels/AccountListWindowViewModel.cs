using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace K42un0k0SnsDeck.ViewModels
{
    class AccountListWindowViewModel : BindableBase
    {
        private Func<IContainerProvider> _getContainer;
        public AccountListWindowViewModel(Func<IContainerProvider> getContainer)
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
    }
}
