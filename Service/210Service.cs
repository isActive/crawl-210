using _210_Crawl.SystemHelper;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _210_Crawl
{
    class _210Service : ISiteService
    {
        private string _url;
        private SiteData SiteData;
        private RequestXNet request;
        private HtmlLoader htmlLoader;
        private static string domain = "https://hentaivn.run/";

        private static string cCookie = null;
        void InitConfig()
        {
            SiteData = new SiteData();
            request = new RequestXNet();
            htmlLoader = new HtmlLoader();
        }
        void CloudFlareBypassConfig()
        {
            request.AddCookie(cCookie);
            request.UserAgent("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/112.0.0.0 Safari/537.36");
        }
        string GetApiGetChapters()
        {
            var sourceData = request.Get(_url);
            return domain + Regex.Match(sourceData, "\"GET\", \"(.*?)\"").Groups[1].Value;
        }

        public _210Service(string url,string cookie)
        {
            InitConfig();

            CloudFlareBypassConfig();

            this._url = url;

            cCookie = cookie;
        }
        public SiteData LoadDataFromSite()
        {
            string sApi = GetApiGetChapters();
            var showListChapters = request.Get(sApi);
            htmlLoader.LoadHtml(showListChapters);
            var nodes = htmlLoader.SelectNodes("//table[@class=\"listing\"]//a[@href]");
            foreach (var node in nodes)
            {
                SiteData.GetNameChaps().Add(node.InnerText);
                SiteData.NameFolder = Regex.Match(sApi, "idlinkanime=([\\w-]+)").Groups[1].Value;
                SiteData.GetChaps().Add(domain + Regex.Match(node.OuterHtml, "href=\"/(.*?)\"").Groups[1].Value);
            }

            return SiteData;
        }
        public async Task DownImageFromChapter()
        {
            DownImage downImage = new DownImage();
            for (int i = 0; i < SiteData.GetChaps().Count; i++)
            {
                int nameImage = 1;
                request.AddHeader("referer", SiteData.GetChaps()[i]);
                request.AddCookie($"{cCookie}tataxoff=1");
                string loadChapter = request.Get(SiteData.GetChaps()[i]);
                var lImage = Regex.Matches(loadChapter, "<img src=\"([^\"]+\\?imgmax=1200)\" alt=\"[^\"]+\" />");
                ConsoleHelper.WriteMessage($"{SiteData.GetNameChaps()[i]} - {lImage.Count} Image", new Random().Next(0, 11));
                foreach (Match match in lImage)
                    downImage.DownLoadImage(match.Groups[1].Value, SiteData.NameFolder, SiteData.GetNameChaps()[i], nameImage++);
            }
        }
        //bool isVerifyRobot(string source)
        //{
        //    return source.Contains("Xác minh không phải Robot!") ? true : false;
        //}
    }
}
