using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotStation.Models;

namespace BotStation.Adapters
{
    public interface IWebsiteSourceAdapter
    {
        public IEnumerable<ScrapingResults> InitiateScraping();
    }
}
