using K42un0k0SnsDeck.ViewModels;
using System.Windows;

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


        private void OpenAccountList(object sender, RoutedEventArgs e)

        {
            var vm = (MainWindowViewModel)this.DataContext;
            vm.OnOpenAccountListWindow(this);
        }
    }
}
