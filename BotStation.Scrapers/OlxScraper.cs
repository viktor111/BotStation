using BotStation.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BotStation.Scrapers
{
    public class OlxScraper
    {
        public IEnumerable<ScrapingResults> InitiateOlxScraping()
        {
            var keyWordList = new List<string>()
            {
                "ps5",
                "playstation 5",
                "пс5",
                "плейстеишан 5"
            };

            var listOfScrapingResults = new List<ScrapingResults>();

            int i = 0;

            foreach (var keyword in keyWordList)
            {
                var uriBase = new Uri($"https://www.olx.bg/ads/q-{keyword}/");

                while (i <= 5)
                {
                    i++;
                    var pagedUri = new Uri($"{uriBase}?page={i}");
                   
                    var web = new HtmlWeb();
                    var document = web.Load(pagedUri);

                    var node = document.DocumentNode.SelectSingleNode("//*[contains(@id,'offers_table')]");

                    foreach (var child in node.ChildNodes)
                    {
                        if (child.NodeType == HtmlNodeType.Element)
                        {
                            var linksHtmlNodeCollection = child.SelectNodes("//*[contains(@data-cy, 'listing-ad-title')]");

                            for (int j = 0; j < linksHtmlNodeCollection.Count; j++)
                            {
                                var linksHtmlNode = linksHtmlNodeCollection[j];

                                var productPageUri = linksHtmlNode.Attributes["href"].Value;

                                var productPage = web.Load(productPageUri);

                                var titleHtmlNode = productPage.DocumentNode.SelectSingleNode("//h1");
                                var priceHtmlNode = productPage.DocumentNode.SelectSingleNode("//*[contains(@class, 'pricelabel__value not-arranged')]");

                                if(priceHtmlNode is null) continue;

                                var priceConverted = Convert.ToDecimal(priceHtmlNode.InnerHtml.Split()[0]);


                                var scrapingResult = new ScrapingResults()
                                {
                                    Price = priceConverted,
                                    Title = titleHtmlNode.InnerHtml,
                                    Uri = new Uri(productPageUri)
                                };

                                listOfScrapingResults.Add(scrapingResult);
                            }
                        }
                    }
                }
            }

            return listOfScrapingResults;
        }
    }
}
