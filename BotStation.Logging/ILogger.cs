using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotStation.Models;

namespace BotStation.Logging
{
    public interface ILogger
    {
        public void Log(LogData logData);
    }
}
