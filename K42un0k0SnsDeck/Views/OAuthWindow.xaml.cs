using K42un0k0SnsDeck.Common;
using K42un0k0SnsDeck.Views.OAuthContext;
using System;
using System.Windows;

namespace K42un0k0SnsDeck.Views
{
    public partial class OAuthWindow : Window
    {
        public OAuthWindow(IOAuthContext context, Action onSuccess)
        {
            InitializeComponent();
            _onSuccess = onSuccess;
            _context = context;
        }

        private readonly Action _onSuccess;
        private readonly IOAuthContext _context;

        private void WebView_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                webView.Source = _context.OAuthUrl;
                webView.NavigationStarting += (s, e) =>
                {
                    System.Diagnostics.Debug.Print(e.Uri);
                    if (e.Uri.StartsWith(_context.CallbackUrl))
                    {
                        _context.Usecase.exec(new Uri(e.Uri));
                        e.Cancel = true;
                        _onSuccess();
                        Close();
                    }
                };
            }
            catch (AggregateException err)
            {
                MessageBoxUtil.ShowError(err);
                Close();
            }
            catch (Exception err)
            {
                MessageBoxUtil.ShowError(err);
                Close();
            }
        }
    }
}
