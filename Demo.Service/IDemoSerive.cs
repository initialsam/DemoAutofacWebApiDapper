using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Service
{
    public interface IDemoSerive
    {
        string HappyString(int number);
        bool DemoCrud(int value);
        string GetAccount(int value);
        string GetAccount(string key, int value);
        Guid MyGuid { get; }
    }
}
