using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;

namespace BotStation.Cli.Utils
{
    public static class Print<T>
    {
        public static void Info(string data)
        {
            ColorManager.Info();
            Console.WriteLine("[.] "  + data);
            ColorManager.ResetColor();
        }

        public static void Error(string data)
        {
            ColorManager.Error();
            Console.WriteLine("[-] " + data);
            ColorManager.ResetColor();
        }

        public static void Success(string data)
        {
            ColorManager.Success();
            Console.WriteLine("[+] " + data);
            ColorManager.ResetColor();
        }

        public static void Warning(string data)
        {
            ColorManager.Warning();
            Console.WriteLine("[!] " + data);
            ColorManager.ResetColor();
        }

        public static void Table(IEnumerable<T> data)
        {
            ConsoleTable.From(data).Write();
        }
    }
}
