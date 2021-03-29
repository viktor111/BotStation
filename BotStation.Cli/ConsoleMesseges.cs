using BotStation.Cli.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotStation.Cli
{
    public class ConsoleMesseges
    {
        public void DisplayHelp()
        {
            Print<string>.Success("Help called");
            Print<string>.Info("Commands are read in this format - [action] [data]");
            Print<string>.Info("[action] - calls the action you wish to invoke");
            Print<string>.Info("[data] - provides data for that action if nesscery");
            Print<string>.Info("---------------------------------------------------------------------");
            Print<string>.Info("Commands :");
            Print<string>.Info("[mount] [number] - mounts the adapter for scraping 1 - olx, 2 - ozone 3 - technomarket, 4 - technopolis");
            Print<string>.Info("[begin] [now] - begin to gather the data");
            Print<string>.Info("[sort] [number] - sorts the data by price");
            Print<string>.Info("[help] [me] - dsiplay help");
            Print<string>.Info("[exit] [now] - dsiplay help");
            Print<string>.Info("---------------------------------------------------------------------");            
        }
    }
}
