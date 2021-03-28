using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotStation.Models;

namespace BotStation.Adapters
{
    public class OzoneWebsiteSourceAdapter : IWebsiteSourceAdapter
    {
        public IEnumerable<ScrapingResults> InitiateScraping()
        {
            Console.WriteLine("Ozone screp");
            return null;
        }
    }
}
