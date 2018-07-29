using System;
using System.Net;
using Caliburn.Micro;
using System.Threading.Tasks;
using System.Net.Http;


namespace Insta_Downloader
{
    public class Parser : Screen
    {


        /// <summary>
        /// Getting image direct link
        /// </summary>
        /// <returns>Link to file</returns>
        public string GetDirectLink(string URL)
        {
            
            WebClient _client = new WebClient();

            try
            {                
                string _source = _client.DownloadString(URL);

                int _startIndex = _source.IndexOf("<meta property=\"og:image\" content=\"");
                _source = _source.Substring(_startIndex + 35);

                int _endIndex = _source.IndexOf("/>");
                _source = _source.Remove(_endIndex - 2);
                
                return _source;
            }   
            
            catch(WebException ex)
            {
                ex.ToString();
                return string.Empty;
            }  
            
            finally
            {
                _client.Dispose();
            }       
            
            
        }



        /// <summary>
        /// Getting file extension
        /// </summary>
        /// <param name="URL"> Direct url to file </param>
        /// <returns> MediaType as string </returns>
        private string GetFileExtension(string URL)
        {
            HttpClient _client = new HttpClient();
            Task<HttpResponseMessage> _response = _client.GetAsync(URL);
            string _filetype = _response.Result.Content.Headers.ContentType.MediaType;
            int _extensionStart = _filetype.IndexOf('/') + 1;
            _filetype = _filetype.Substring(_extensionStart);
            return _filetype;
        }


        /// <summary>
        /// Check is it instagram link
        /// </summary>
        /// <param name="URL"></param>
        /// <returns></returns>
        public bool IsInstagramLink(string URL)
        {
            if (URL.Contains("instagram"))
            {
                Uri _uriResult;
                bool _result = Uri.TryCreate(URL, UriKind.Absolute, out _uriResult)
                    && _uriResult.Scheme == Uri.UriSchemeHttps;
                
                return _result;
            }           
            
            return false;
        }


        public string CombineFileName(string URL)
        {
            string _fileName = GetFileName(URL);
            string _fullPath = PathSaver.lastPath + _fileName + '.' + GetFileExtension(URL);
            return _fullPath; 
            
        }

        
        private string GetFileName(string URL)
        {
            int startIndex = URL.LastIndexOf('/');
            string _fileName = URL.Substring(startIndex);
            _fileName = _fileName.Remove(9);
            return _fileName;
        }



        




    }
}
