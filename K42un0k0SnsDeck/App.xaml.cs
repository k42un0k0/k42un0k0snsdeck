using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace K42un0k0SnsDeck
{
    using Views;
    using ViewModels;
    using Prism.Unity;
    using Prism.Ioc;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {

        //protected override void OnStartup(StartupEventArgs e)
        //{
        //    base.OnStartup(e);
        //    var w = new MainWindow();
        //    var vm = new MainWindowViewModel();

        //    w.DataContext = vm;
        //    w.Show();

        //}
        protected override Window CreateShell()
        {
            var w = Container.Resolve<MainWindow>();
            return w;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}
