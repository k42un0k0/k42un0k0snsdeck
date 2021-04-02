using System.Windows;
using K42un0k0SnsDeck.Views;
using Prism.Unity;
using Prism.Ioc;
using System.Threading;
using K42un0k0SnsDeck.Views.Helper;

namespace K42un0k0SnsDeck
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        // Mutexの名前
        // 本来は一意になるような名前にします。
        private static readonly string mutexName = "Sample";

        // Mutexを生成します。
        private static readonly Mutex mutex = new Mutex(false, mutexName);

        // Mutexの所有権の有無を保持するフラグ(true:所有権有り/false:所有権無し)
        private static bool hasHandle = false;

        protected override void OnStartup(StartupEventArgs e)
        {
            // Mutexの所有権を取得します。
            // 最初に起動したアプリのみ所有権を取得できます。
            hasHandle = mutex.WaitOne(0, false);

            // 取得できない場合、すでに起動済みとみなします。
            if (!hasHandle)
            {
                MessageBox.Show("2重起動できません。");

                // アプリケーションを終了します。
                this.Shutdown();
                return;
            }

            base.OnStartup(e);
        }

        protected override Window CreateShell()
        {
            var w = Container.Resolve<MainWindow>();
            return w;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<TwitterOAuthHelper>();
        }
    }
}
