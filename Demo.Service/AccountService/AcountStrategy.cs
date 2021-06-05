using Demo.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Service
{
    public class AcountStrategy: IAcountStrategy
    {
        private readonly IComponentLocator _componentLocator;
        private Dictionary<string, IAccountService> _dictionary;
        public AcountStrategy(IComponentLocator componentLocator)
        {
            _componentLocator = componentLocator;
            _dictionary = new Dictionary<string, IAccountService>();
            _dictionary.Add("A", _componentLocator.ResolveKeyedComponent<IAccountService>(nameof(AccountAService)));
            _dictionary.Add("B", _componentLocator.ResolveKeyedComponent<IAccountService>(nameof(AccountBService)));
            _dictionary.Add("C", _componentLocator.ResolveKeyedComponent<IAccountService>(nameof(AccountCService)));
        }

        public IAccountService GetAccountService(string key)
        {
            return _dictionary[key];
        }


    }
}
