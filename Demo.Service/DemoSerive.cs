﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Service
{
    public class DemoSerive:IDemoSerive
    {
        public string HappyString(int value)
        {
            return $"^^{value}^^";
        }
    }
}
