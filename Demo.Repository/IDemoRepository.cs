using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Repository
{
    public interface IDemoRepository
    {
        bool DemoCrud(int id);
    }
}
