using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InjectedLearning
{
    public class CurrentMarket : ICurrentMarket
    {
        public Market GetCurrentMarket()
        {
            return new Market() { ID = 1, MarketName = "English"};
        }
    }
}
