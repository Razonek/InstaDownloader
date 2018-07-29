using Caliburn.Micro;


namespace Insta_Downloader.ViewModels
{


    public delegate void AutoDetection(bool detection);



    public class InstaDownloaderViewModel : Screen
    {

        public static AutoDetection AutoDetectionToggle;
        Downloader Downloader;
        



        public InstaDownloaderViewModel()
        {
            this.DisplayName = "Insta Downloader";
            Downloader = new Downloader();
            PathSaver.lastPath = Properties.Settings.Default.savePath;
            
        }


        protected override void OnDeactivate(bool close)
        {
            Properties.Settings.Default.savePath = PathSaver.lastPath;
            Properties.Settings.Default.Save();
        }


        private bool _autoDownloadingOnCopyLink;
        public bool autoDownloadingOnCopyLink
        {
            get { return _autoDownloadingOnCopyLink; }
            set
            {
                _autoDownloadingOnCopyLink = value;
                AutoDetectionToggle(value);
                NotifyOfPropertyChange("autoDownloadingOnCopyLink");
            }
        }

        public void SetSavePath()
        {
            PathSaver.SelectDestination();
        }


        public void DownloadImage()
        {
            Downloader.DownloadImage();
        }


    }
}
