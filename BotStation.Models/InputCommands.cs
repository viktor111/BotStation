﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotStation.Models.Types;

namespace BotStation.Models
{
    public class InputCommands 
    {
        public string Action { get; set; }

        public string Data { get; set; }  

        public WebsiteSourceType SourceType { get; set; }
    }
}
