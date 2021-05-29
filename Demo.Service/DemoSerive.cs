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
        public readonly IDemoRepository _demoRepository;

        public DemoSerive(IDemoRepository demoRepository)
        {
            _demoRepository = demoRepository;
        }
        public bool DemoCrud(int value)
        {
            return _demoRepository.DemoCrud(value);
        }

        public string HappyString(int value)
        {
            return $"^^{value}^^";
        }
    }
}
