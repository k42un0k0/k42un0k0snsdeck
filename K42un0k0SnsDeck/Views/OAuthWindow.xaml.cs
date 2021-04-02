using K42un0k0SnsDeck.Constants;
using K42un0k0SnsDeck.Usecases;
using K42un0k0SnsDeck.Views.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace K42un0k0SnsDeck.Views
{
    /// <summary>
    /// TwitterOAuthWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class OAuthWindow : Window
    {
        public OAuthWindow()
        {
            InitializeComponent();
            Loaded += (_1, _2) => CheckDependencies();
        }

        private IOAuthHelper OAuthHelper { get; set; }
        private ICreateAccountWhenOAuthUsecase Usecase { get; set; }

        public void SetDependencies(IOAuthHelper helper, ICreateAccountWhenOAuthUsecase usecase)
        {
            OAuthHelper = helper;
            Usecase = usecase;
        }

        private void CheckDependencies()
        {
            if (OAuthHelper == null || Usecase == null) throw new NullReferenceException("oauth helper か usecase がありません, SetDependenciesを実行してください");
        }

        private void WebView_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var oauthUrl = OAuthHelper.GetOAuthUrl();
                webView.Source = new Uri(oauthUrl);
                webView.NavigationStarting += (s, e) =>
                {
                    System.Diagnostics.Debug.Print(e.Uri);
                    if (e.Uri.StartsWith(AppConfig.Singleton.TwitterCallbackUrl))
                    {
                        var command = OAuthHelper.FetchUsecaseCommandFromRedirectUrl(new Uri(e.Uri));
                        Usecase.exec(command);
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
