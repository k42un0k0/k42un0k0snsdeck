using K42un0k0SnsDeck.Infra.Http;
using K42un0k0SnsDeck.Usecases;
using Prism.Ioc;
using System;
using System.Windows;
using Unity;

namespace K42un0k0SnsDeck.Views
{

    /// <summary>
    /// AccountListWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class AccountListWindow : Window
    {
        private enum OAuthProvider
        {
            Twitter,
            Facebook,
        }

        [Dependency]
        public IContainerProvider Container { get; set; }

        public AccountListWindow()
        {
            InitializeComponent();
        }

        private void ShowOAuthWindow(OAuthProvider provider)
        {
            OAuthWindow window;
            Uri oauthUrl;
            switch (provider)
            {
                case OAuthProvider.Twitter:
                    oauthUrl = Container.Resolve<ITwitterClient>().GetOAuthUrl();
                    window = new OAuthWindow(oauthUrl, Container.Resolve<CreateTwitterAccountWhenOAuthUsecase>());
                    break;
                case OAuthProvider.Facebook:
                    oauthUrl = Container.Resolve<IFacebookClient>().GetOAuthUrl();
                    window = new OAuthWindow(oauthUrl, Container.Resolve<CreateFacebookAccountWhenOAuthUsecase>());
                    break;
                default:
                    throw new NotImplementedException();
            }
            window.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ShowOAuthWindow(OAuthProvider.Twitter);
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            ShowOAuthWindow(OAuthProvider.Facebook);
        }
    }
}
