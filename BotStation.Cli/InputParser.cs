using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotStation.Models;
using BotStation.Models.Types;

namespace BotStation.Cli
{
    public static class InputParser
    {
        public static InputCommands ParseInputCommands(string input)
        {
            var inputCommands = SplitCommands(input);

            return inputCommands;
        }

        public static void ValidateInput(InputCommands inputCommands)
        {
            var action = inputCommands.Action;
            var data = inputCommands.Data;

            if (string.IsNullOrEmpty(action)) throw new Exception(typeof(InputCommands).GetProperties()[0].ToString());
            if (string.IsNullOrEmpty(data)) throw new Exception(typeof(InputCommands).GetProperties()[1].ToString());

            if (string.IsNullOrWhiteSpace(action)) throw new Exception(typeof(InputCommands).GetProperties()[0].ToString());
            if (string.IsNullOrWhiteSpace(data)) throw new Exception(typeof(InputCommands).GetProperties()[1].ToString());
        }

        public static InputCommands SetScrapingType(InputCommands inputCommands)
        {
            var commands = inputCommands;
            var data = inputCommands.Data;

            if (data == "1")
            {
                commands.SourceType = WebsiteSourceType.Olx;
            }

            if (data == "2")
            {
                commands.SourceType = WebsiteSourceType.Ozone;
            }

            if (data == "3")
            {
                commands.SourceType = WebsiteSourceType.Technomarket;
            }

            if (data == "4")
            {
                commands.SourceType = WebsiteSourceType.Technopolis;
            }

            return commands;
        }

        private static InputCommands SplitCommands(string input)
        {
            try
            {
                var inputArray = input.Split();

                var action = inputArray[0].ToLower();
                var data = inputArray[1].ToLower();

                var commands = new InputCommands()
                {
                    Action = action,
                    Data = data
                };

                return commands;
            }
            catch
            {
                throw new Exception("input not in right format should be - [action] [data]");
            }
        }
    }
}
