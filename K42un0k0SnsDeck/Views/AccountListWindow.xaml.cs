using K42un0k0SnsDeck.Usecases;
using K42un0k0SnsDeck.Views.Helper;
using Prism.Ioc;
using System.Windows;
using Unity;

namespace K42un0k0SnsDeck.Views
{
    /// <summary>
    /// AccountListWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class AccountListWindow : Window
    {
        [Dependency]
        public IContainerProvider Container{ get; set;}

        public AccountListWindow()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<OAuthWindow>();
            window.SetDependencies(Container.Resolve<TwitterOAuthHelper>(), Container.Resolve<CreateTwitterAccountWhenOAuthUsecase>());
            window.Show();

        }
    }
}
