using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BotStation.DependancyInjector
{
    public class DependancyResolver
    {
        DependancyContainer _container;

        public DependancyResolver(DependancyContainer container)
        {
            _container = container;
        }

        public T GetService<T>()
        {
            return (T)GetService(typeof(T));
        }

        private object GetService(Type type)
        {
            Dependancy dependancy = _container.GetDependancy(type);
            ConstructorInfo constructor = dependancy.Type.GetConstructors().Single();
            ParameterInfo[] parameters = constructor.GetParameters().ToArray();

            if (parameters.Length > 0)
            {
                object[] parameterImplementations = new object[parameters.Length];

                for (int i = 0; i < parameters.Length; i++)
                {
                    parameterImplementations[i] = GetService(parameters[i].ParameterType);
                }

                return CreateImplementation(dependancy, t => Activator.CreateInstance(t, parameterImplementations));
            }
            return CreateImplementation(dependancy, t => Activator.CreateInstance(t));
        }

        public object CreateImplementation(Dependancy dependancy, Func<Type, object> factory)
        {
            if (dependancy.Implemented)
            {
                return dependancy.Implementation;
            }

            object implementation = factory(dependancy.Type);

            if (dependancy.Lifetimes == DependancyLifetimes.Transient)
            {
                dependancy.AddImplementaion(implementation);
            }
            return implementation;
        }
    }
}
