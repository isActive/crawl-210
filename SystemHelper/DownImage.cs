using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace _210_Crawl
{
    public class DownImage
    {
        public WebClient DownLoadImage(string _linkImage, string _nameLinkFolder, string _nameFolderChapter, int _nameImage)
        {
            using (WebClient webClient = new WebClient())
            {
                webClient.Headers.Add("referer", "https://hentaivn.run/");
                try
                {
                    string validFolderName = StringHelper.GetInvalidNameFolder(_nameLinkFolder);
                    string path = AppDomain.CurrentDomain.BaseDirectory + "\\data\\" + validFolderName;
                    string pathChapter = AppDomain.CurrentDomain.BaseDirectory + "\\data\\" + validFolderName + $"\\{_nameFolderChapter}";
                    string filename = Path.Combine(path, pathChapter);
                    try
                    {
                        if (!Directory.Exists(path))
                        {
                            DirectoryInfo di = Directory.CreateDirectory(path);
                        }
                        if (!Directory.Exists(pathChapter))
                        {
                            DirectoryInfo di = Directory.CreateDirectory(pathChapter);
                        }
                    }
                    catch
                    {

                    }
                    webClient.Credentials = CredentialCache.DefaultNetworkCredentials;
                    webClient.DownloadFile(_linkImage, filename + "\\" + _nameImage + ".jpg");
                    webClient.Dispose();
                    return webClient;
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
