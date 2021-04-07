using K42un0k0SnsDeck.ViewModels;
using Prism.Ioc;
using System.Windows;
using Unity;

namespace K42un0k0SnsDeck.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [Dependency]
        public IContainerProvider Container { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }
        private MainWindowViewModel ViewModel { get; set; }

        private void OpenAccountList(object sender, RoutedEventArgs e)

        {
            ViewModel.OnOpenAccountListWindow(this);
        }

        private void Window_Activated(object sender, System.EventArgs e)
        {
            ViewModel = Container.Resolve<MainWindowViewModel>();

            DataContext = ViewModel;
        }
    }
}
