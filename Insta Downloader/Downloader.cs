using System.Net;

namespace Insta_Downloader
{
    public class Downloader : Parser
    {

        Clipboard Clipboard;

        public Downloader()
        {
            Clipboard.NewLink += AutoDownload;
            Clipboard = new Clipboard();
        }


        private void AutoDownload()
        {
            DownloadImage();
        }


        public void DownloadImage()
        {

            string _link = Clipboard.GetLinkFromClipboard();            

            if (_link == string.Empty)
            {
                return;
            }

            string _directLink = GetDirectLink(_link);

            if(_directLink != string.Empty)
            {

                string _savePath = CombineFileName(_directLink);


                using (WebClient _client = new WebClient())
                {
                    _client.DownloadFile(_directLink, _savePath);
                }
            }
                      
            
        }


    }
}
