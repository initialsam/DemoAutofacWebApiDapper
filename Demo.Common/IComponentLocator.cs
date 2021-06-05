using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Common
{
    public interface IComponentLocator
    {
        T ResolveComponent<T>();
        T ResolveKeyedComponent<T>(string key);
    }
}
