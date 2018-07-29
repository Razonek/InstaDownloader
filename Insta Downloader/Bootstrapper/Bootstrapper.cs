using System.Windows;
using Caliburn.Micro;


namespace Insta_Downloader
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ViewModels.InstaDownloaderViewModel>();
        }
    }
}
