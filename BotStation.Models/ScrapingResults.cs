using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BotStation.Models
{
    public class ScrapingResults
    {
        public string Title { get; set; }

        public decimal Price { get; set; }

        public Uri Uri { get; set; }
    }
}
