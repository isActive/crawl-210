using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace _210_Crawl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "CRAWL 210";

            string url = ReadInput("INPUT LINK: ");

            string cCookie = ReadInput("INPUT COOKIE: ");

            Console.Clear();

            Chapters(url, cCookie);

            Console.ReadLine();
        }
        private static string ReadInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        static void Chapters(string url,string cookie)
        {
            _210Service _210Service = new _210Service(url, cookie);
            _210Service.LoadDataFromSite();
            _210Service.DownImageFromChapter().Wait();

            Console.WriteLine("CRAWL DONE");
        }
    }
}
