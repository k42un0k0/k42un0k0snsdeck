using K42un0k0SnsDeck.Constants;
using K42un0k0SnsDeck.Usecases;
using System;
using System.Windows;

namespace K42un0k0SnsDeck.Views
{

    /// <summary>
    /// TwitterOAuthWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class OAuthWindow : Window
    {
        public OAuthWindow(Uri oauthUrl, ICreateAccountWhenOAuthUsecase usecase)
        {
            InitializeComponent();
            _oauthUrl = oauthUrl;
            _usecase = usecase;
        }

        private Uri _oauthUrl;
        private ICreateAccountWhenOAuthUsecase _usecase;

        private void WebView_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                webView.Source = _oauthUrl;
                webView.NavigationStarting += (s, e) =>
                {
                    System.Diagnostics.Debug.Print(e.Uri);
                    if (e.Uri.StartsWith(AppConfig.Singleton.TwitterCallbackUrl))
                    {
                        _usecase.exec(new Uri(e.Uri));
                    }
                };
            }
            catch (AggregateException err)
            {
                var errorMessages = "";
                foreach (var errInner in err.InnerExceptions)
                {
                    errorMessages += errInner.Message + "\n";
                }

                MessageBox.Show(errorMessages, "エラー");
                Close();
            }
        }
    }
}
