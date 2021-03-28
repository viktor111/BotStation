using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotStation.DependancyInjector
{
    public class DependancyContainer
    {
        List<Dependancy> _dependancies;

        public DependancyContainer()
        {
            _dependancies = new();
        }

        public void AddSingleton<T>()
        {
            _dependancies.Add(new Dependancy(typeof(T), DependancyLifetimes.Singleton));
        }

        public void AddTransient<T>()
        {
            _dependancies.Add(new Dependancy(typeof(T), DependancyLifetimes.Transient));
        }

        public Dependancy GetDependancy(Type type)
        {
            return _dependancies.First(d => d.Type.Name == type.Name);
        }
    }
}
