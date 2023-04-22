using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _210_Crawl.SystemHelper
{
    public class ConsoleHelper
    {
        public static void WriteMessage(string message, int type)
        {
            if (!string.IsNullOrEmpty(message))
            {
                if (type == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"[{DateTime.Now}] • {message}");
                }
                if (type == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"[{DateTime.Now}] • {message}");
                }
                if (type == 3)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"[{DateTime.Now}] • {message}");
                }
                if (type == 4)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"[{DateTime.Now}] • {message}");
                }
                if (type == 5)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"[{DateTime.Now}] • {message}");
                }
                if (type == 6)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"[{DateTime.Now}] • {message}");
                }
                if (type == 7)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"[{DateTime.Now}] • {message}");
                }
                if (type == 8)
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine($"[{DateTime.Now}] • {message}");
                }
                if (type == 9)
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine($"[{DateTime.Now}] • {message}");
                }
                if (type == 10)
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine($"[{DateTime.Now}] • {message}");
                }

            }
            else
            {
                Console.WriteLine("Invaid message.");
            }
        }
    }
}
