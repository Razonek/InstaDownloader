using System;
using Caliburn.Micro;
using System.Windows;
using System.Windows.Threading;
using Insta_Downloader.ViewModels;

namespace Insta_Downloader
{

    public delegate void NewLinkCopied();

    public class Clipboard : Parser
    {

        public static NewLinkCopied NewLink;
        
        DispatcherTimer _timer;

        private string _lastLink;



        public Clipboard()
        {
            InstaDownloaderViewModel.AutoDetectionToggle += AutoDetect;            
            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            _timer.Tick += ClipboardChangeChecker;
            
        }

        /// <summary>
        /// Turn on/off timer for autodownloading photos when link is copied
        /// </summary>
        /// <param name="detection"></param>
        private void AutoDetect(bool detection)
        {
            _timer.IsEnabled = detection;
        }

        /// <summary>
        /// Checking Windows.Clipboard if contains website url
        /// </summary>
        /// <returns> Website link or empty </returns>
        public string GetLinkFromClipboard()
        {
            if (System.Windows.Clipboard.ContainsText(TextDataFormat.Text))
            {
                 if(IsInstagramLink(System.Windows.Clipboard.GetText()))
                {
                    return System.Windows.Clipboard.GetText();
                }
                    
            }

            NoLinkNotification();
            return string.Empty;

        }


        /// <summary>
        /// DispatcherTimer tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClipboardChangeChecker(object sender, EventArgs e)
        {
            if(System.Windows.Clipboard.ContainsText(TextDataFormat.Text))
            {
                if (IsInstagramLink(System.Windows.Clipboard.GetText()))
                {
                    string _actualLink = GetLinkFromClipboard();
                    if (_actualLink != _lastLink)
                    {
                        NewLink();
                        _lastLink = _actualLink;
                    }
                }
            }
            
        }


        /// <summary>
        /// Display notification if clipboard don't contain any link
        /// </summary>
        private static void NoLinkNotification()
        {
            WindowManager _manager = new WindowManager();
            string _noLinkMessage = "You don't have copied any instagram link";
            _manager.ShowWindow(new NotificationViewModel(_noLinkMessage));
        }

    }
}
