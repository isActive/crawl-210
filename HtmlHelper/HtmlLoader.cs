using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _210_Crawl
{
    public class HtmlLoader
    {
        private readonly HtmlWeb web;
        private readonly HtmlDocument doc = new HtmlDocument();
        private readonly string _url;
        public HtmlLoader(string url)
        {
            this._url = url;
            web = new HtmlWeb();
        }
        public HtmlLoader()
        {
            web = new HtmlWeb();
        }

        public HtmlDocument Load() => web.Load(_url);
        public HtmlDocument LoadHtml(string html)
        {
            doc.LoadHtml(html);
            return doc;
        }
        public HtmlNode SelectSingleNode(string tagName) => doc.DocumentNode.SelectSingleNode(tagName);
        public HtmlNodeCollection SelectNodes(string tagName) => doc.DocumentNode.SelectNodes(tagName);
    }
}
