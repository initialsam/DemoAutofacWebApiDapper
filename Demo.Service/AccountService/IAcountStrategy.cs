﻿using Demo.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Service
{
    public interface IAcountStrategy
    {
        IAccountService GetAccountService(string key);
    }
}
