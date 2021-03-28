using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BotStation.Adapters;
using BotStation.Cli.Utils;
using BotStation.Models;
using BotStation.Models.Types;

namespace BotStation.Cli
{
    public class CommandMapper
    {
        public IWebsiteSourceAdapter MapScrapeToSource(InputCommands inputCommands)
        {
            IWebsiteSourceAdapter websiteSourceAdapter;

            Print<ScrapingResults>.Info($"Setting source for scraping");

            if (inputCommands.SourceType == WebsiteSourceType.Olx)
            {
                Print<ScrapingResults>.Success($"Source set to {inputCommands.SourceType.ToString()} waiting for command [begin] [scrape]");
                websiteSourceAdapter = new OlxWebsiteSourceAdapter();
                return websiteSourceAdapter;
            }

            if (inputCommands.SourceType == WebsiteSourceType.Ozone)
            {
                Print<ScrapingResults>.Success($"Source set to {inputCommands.SourceType.ToString()} waiting for command [begin] [scrape]");
                websiteSourceAdapter = new OzoneWebsiteSourceAdapter();
                return websiteSourceAdapter;
            }

            if (inputCommands.SourceType == WebsiteSourceType.Technomarket)
            {
                Print<ScrapingResults>.Success($"Source set to {inputCommands.SourceType.ToString()} waiting for command [begin] [scrape]");
                websiteSourceAdapter = new TechnomarketWebsiteSourceAdapter();
                return websiteSourceAdapter;
            }

            if (inputCommands.SourceType == WebsiteSourceType.Technopolis)
            {
                Print<ScrapingResults>.Success($"Source set to {inputCommands.SourceType.ToString()} waiting for command [begin] [scrape]");

                websiteSourceAdapter = new TechnopolisWebisteSourceAdapter();
                return websiteSourceAdapter;
            }

            return null;
        }

    }
}
