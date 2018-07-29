using System;
using System.Windows.Forms;

namespace Insta_Downloader
{

    public class PathSaver
    {

        private static string _lastPath;
        public static string lastPath
        {
            get
            {
                if (_lastPath == string.Empty || _lastPath == null)
                {
                    _lastPath = Environment.CurrentDirectory;
                }
                    
                return _lastPath;
            }
            set
            {
                _lastPath = value;
            }
        }



        public static string SelectDestination()
        {
            FolderBrowserDialog _browser = new FolderBrowserDialog();
            DialogResult _result = _browser.ShowDialog();
            if(_result == DialogResult.OK)
            {
                string _path = _browser.SelectedPath;
                lastPath = _path;
                return _path;
            }

            else
            {
                return lastPath;
            }
        }

    }
}
