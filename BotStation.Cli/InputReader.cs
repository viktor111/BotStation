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
        public InputReader()
        {

        }

        public void BeginWaitForInput()
        {
            var commandMapper = new CommandMapper();
            InputCommands commands = null;
            var consoleMessages = new ConsoleMesseges();
            IWebsiteSourceAdapter scraperSource = null;
            IEnumerable<ScrapingResults> results = null;

            consoleMessages.DisplayHelp();

            while (true)
            {
                Console.Write("> ");

                try
                {
                    string input = Console.ReadLine();
                    commands = InputParser.ParseInputCommands(input);                    

                    InputParser.ValidateInput(commands);

                    if (commands.Action is "mount" && commands.Data is not null)
                    {
                        commands = InputParser.SetScrapingType(commands);
                        scraperSource = commandMapper.MapScrapeToSource(commands);
                    }
                    else if (commands.Action is "begin" && commands.Data is "now")
                    {
                        if(scraperSource is not null) 
                        {
                            Print<ScrapingResults>.Info("Be patient data is being loaded...");
                            results = scraperSource.InitiateScraping();
                            Print<ScrapingResults>.Table(results);
                            Print<ScrapingResults>.Success("Data loaded");
                            Console.WriteLine();
                        }
                        else
                        {
                            throw new Exception("First mount a scraper");
                        }
                    }
                    else if (commands.Action is "sort")
                    {
                        Print<ScrapingResults>.Success("Sorting phase initiated");
                        Print<ScrapingResults>.Info($"Sorting porducts low point price {commands.Data}");
                        var price = Convert.ToDecimal(commands.Data);
                        var newResults = results.Where(r => r.Price > price).ToList();
                        Print<ScrapingResults>.Table(newResults);
                    }
                    else if(commands.Action is "help" && commands.Data is "me")
                    {
                        consoleMessages.DisplayHelp();
                    }
                    else if (commands.Action is "exit" && commands.Data is "now")
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        Print<string>.Warning("Command not recognized");
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
