using Caliburn.Micro;


namespace Insta_Downloader.ViewModels
{
    public class NotificationViewModel : Screen
    {


        public NotificationViewModel(string notification)
        {
            this.notification = notification;
        }


        private string _notification;
        public string notification
        {
            get { return _notification; }
            private set
            {
                _notification = value;
                NotifyOfPropertyChange("notification");
            }
        }
           

        public void OkButton()
        {
            TryClose();
        }


    }
}
