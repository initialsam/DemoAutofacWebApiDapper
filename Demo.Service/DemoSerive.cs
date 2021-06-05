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
        public DemoSerive(IDemoRepository demoRepository, IComponentLocator componentLocator)
        {
            _demoRepository = demoRepository;
            _componentLocator = componentLocator;
        }
        public bool DemoCrud(int value)
        {
            return _demoRepository.DemoCrud(value);
        }

        public string HappyString(int value)
        {
            return $"^^{value}^^";
        }

        public string GetFoo(int value)
        {
            var fooService = _componentLocator.ResolveComponent<IFooSerive>();
            return fooService.GetFoo(value);
        }
    }
}
