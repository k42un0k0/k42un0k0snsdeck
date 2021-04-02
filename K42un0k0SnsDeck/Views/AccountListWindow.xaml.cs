using Prism.Ioc;
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
            window.Show();

        }
    }
}
