using System;
using System.Collections.Generic;
using System.Text;
using Prism.Commands;
using Prism.Mvvm;

namespace K42un0k0SnsDeck.ViewModels
{
    class MainWindowViewModel : BindableBase
    {

        public MainWindowViewModel()
        {
            _greeting = "こんにちは";
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
