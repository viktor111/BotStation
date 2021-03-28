using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BotStation.Adapters;
using BotStation.Cli.Utils;
using BotStation.Models;

namespace BotStation.Cli
{
    public class InputReader
    {
        public static void BeginWaitForInput()
        {
            var commandMapper = new CommandMapper();
            InputCommands commands = null;
            IWebsiteSourceAdapter scraperSource = null;
            IEnumerable<ScrapingResults> results = null;

            while (true)
            {
                Console.Write("> ");

                try
                {
                    string input = Console.ReadLine();
                    commands = InputParser.ParseInputCommands(input);
                    

                    InputParser.ValidateInput(commands);

                    if (commands.Action == "mount")
                    {
                        commands = InputParser.SetScrapingType(commands);
                        scraperSource = commandMapper.MapScrapeToSource(commands);
                    }

                    if (commands.Action == "begin")
                    {
                        
                        Print<ScrapingResults>.Info("Be patient data is being loaded...");
                        results = scraperSource.InitiateScraping();
                        Print<ScrapingResults>.Table(results);
                        Print<ScrapingResults>.Success("Data loaded");
                        Console.WriteLine();
                    }

                    if (commands.Action == "sort")
                    {
                        Print<ScrapingResults>.Success("Sorting phase initiated");
                        Print<ScrapingResults>.Info($"Sorting porducts low point price {commands.Data}");
                        var price = Convert.ToDecimal(commands.Data);
                        var newResults = results.Where(r => r.Price > price).ToList();
                        Print<ScrapingResults>.Table(newResults);
                    }
                }
                catch (Exception e)
                {
                    Print<ScrapingResults>.Error(e.Message);
                    BeginWaitForInput();
                }
            }
        }
    }
}
