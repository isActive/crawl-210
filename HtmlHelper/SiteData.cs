using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _210_Crawl
{
    public class SiteData : ConfigData
    {
        private List<string> _listChaps = new List<string>();
        private List<string> _listImages = new List<string>();
        private List<string> _listNameChaps = new List<string>();
        private string nameFolder;
        public string NameFolder { get => nameFolder; set => nameFolder = value; }
        public override List<string> GetChaps() => _listChaps;
        public override List<string> GetImages() => _listImages;
        public override List<string> GetNameChaps() => _listNameChaps;
    }
}
