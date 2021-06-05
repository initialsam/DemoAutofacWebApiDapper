using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Common
{
    public class ComponentLocator : IComponentLocator
    {
        private readonly ILifetimeScope _container;
        public ComponentLocator(ILifetimeScope container)
        {
            _container = container;
        }
        public T ResolveComponent<T>()
        {
            return _container.Resolve<T>();
        }

        public T ResolveKeyedComponent<T>(string key)
        {
            return _container.ResolveKeyed<T>(key);
        }
    }
}
