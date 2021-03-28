using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotStation.Models.Types;

namespace BotStation.Models
{
    public class LogData
    {
        public LoggingTypes Type { get; set; }

        public string Message{ get; set; }
    }
}
