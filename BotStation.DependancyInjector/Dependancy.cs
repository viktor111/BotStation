using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotStation.DependancyInjector
{
    public class Dependancy
    {
        public Dependancy(Type type, DependancyLifetimes dependancyLifetimes)
        {
            Type = type;
            Lifetimes = dependancyLifetimes;
        }

        public Type Type { get; set; }

        public DependancyLifetimes Lifetimes { get; set; }

        public object Implementation { get; set; }

        public bool Implemented { get; set; }

        public void AddImplementaion(object impelentation)
        {
            Implementation = impelentation;
            Implemented = true;
        }
    }
}
