using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _210_Crawl
{
    public class StringHelper
    {
        public static string GetInvalidNameFolder(string name)
        {
            char[] invalidChars = Path.GetInvalidFileNameChars();
            string validFolderName = String.Join("_", name.Split(invalidChars, StringSplitOptions.RemoveEmptyEntries));
            return validFolderName;
        }
    }
}
