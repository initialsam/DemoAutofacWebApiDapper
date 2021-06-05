using Demo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Service
{
    public class FooSerive:IFooSerive
    {
        private readonly IDemoRepository _demoRepository;

        public FooSerive(IDemoRepository demoRepository)
        {
            _demoRepository = demoRepository;
        }

        public string GetFoo(int value)
        {
            var a = _demoRepository.GetType();
            return $"Foo|{value}";
        }
    }
}
