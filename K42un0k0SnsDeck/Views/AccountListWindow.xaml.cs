using K42un0k0SnsDeck.ViewModels;
using K42un0k0SnsDeck.Views.OAuthContext;
using Prism.Ioc;
using System;
using System.Windows;
using Unity;

namespace K42un0k0SnsDeck.Views
{
    public partial class AccountListWindow : Window
    {


        [Dependency]
        public AccountListWindowViewModel ViewModel { get; set; }
        [Dependency]
        public OAuthContextProvider oauthContextProvider { get; set; }

        public AccountListWindow()
        {
            InitializeComponent();
        }


        private void ShowOAuthWindow(OAuthProviderEnum provider)
        {

            new OAuthWindow(oauthContextProvider.GetContext(provider), OnOAuthSuccess).Show();
        }
        private void OnOAuthSuccess()
        {
            ViewModel.Load();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ShowOAuthWindow(OAuthProviderEnum.Twitter);
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            ShowOAuthWindow(OAuthProviderEnum.Facebook);
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            DataContext = ViewModel;
            ViewModel.Load();
        }
    }
}
