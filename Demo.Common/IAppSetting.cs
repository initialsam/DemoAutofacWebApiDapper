using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Common
{
    public interface IAppSetting
    {
        string DataContext { get; set; }
        string TestData { get; set; }
    }
}
