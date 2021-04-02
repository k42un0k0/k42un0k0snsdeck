using K42un0k0SnsDeck.Infra.Http;
using K42un0k0SnsDeck.ViewModels;
using System.Windows;
using Unity;

namespace K42un0k0SnsDeck.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        [Dependency]
        public TwitterClient TwitterClient { get; set; }

        private void OpenAccountList(object sender, RoutedEventArgs e)

        {
            TwitterClient.RequestAuthorizationUrl();
            var vm = (MainWindowViewModel)this.DataContext;
            vm.OnOpenAccountListWindow(this);
        }
    }
}
