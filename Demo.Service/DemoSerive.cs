using Demo.Common;
using Demo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Service
{
    public class DemoSerive:IDemoSerive
    {
        private readonly IDemoRepository _demoRepository;
        private readonly IComponentLocator _componentLocator;
        private readonly IAcountStrategy _acountStrategy;
        public Guid MyGuid { get; }
        public DemoSerive(
            IDemoRepository demoRepository, 
            IComponentLocator componentLocator,
            IAcountStrategy acountStrategy)
        {
            _demoRepository = demoRepository;
            _componentLocator = componentLocator;
            _acountStrategy = acountStrategy;
            MyGuid = Guid.NewGuid();
        }
        public bool DemoCrud(int value)
        {
            return _demoRepository.DemoCrud(value);
        }

        public string HappyString(int value)
        {
            return $"^^{value}^^";
        }

        public string GetAccount(int value)
        {
            //沒有特別指定key 就會是最後註冊的AccountCService
            var accountService = _componentLocator.ResolveComponent<IAccountService>();
            return accountService.GetAccount(value);
        }

        public string GetAccount(string key, int value)
        {
            var accountService = _acountStrategy.GetAccountService(key);
            return accountService.GetAccount(value);
        }
    }
}
