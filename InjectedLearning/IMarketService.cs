﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InjectedLearning
{
    public interface IMarketService
    {
        IEnumerable<Market> GetAllMarkets();
    }
}
