using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotStation.Models;
using BotStation.Scrapers;
using HtmlAgilityPack;

namespace BotStation.Adapters
{
    public class OlxWebsiteSourceAdapter : IWebsiteSourceAdapter
    {
        private readonly OlxScraper _olxScraper = new OlxScraper();

        public IEnumerable<ScrapingResults> InitiateScraping()
        {
            return _olxScraper.InitiateOlxScraping();
        }
    }
}
