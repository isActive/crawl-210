using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _210_Crawl
{
    public abstract class ConfigData
    {
        public abstract List<string> GetChaps();
        public abstract List<string> GetImages();
        public abstract List<string> GetNameChaps();
    }
}
