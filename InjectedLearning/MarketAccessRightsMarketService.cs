using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InjectedLearning
{
    public class MarketAccessRightsMarketService : MarketServiceCache
    {
        public MarketAccessRightsMarketService(ISynchronizedObjectInstanceCache cache) : base(cache)
        {
        }

        public override IEnumerable<Market> GetAllMarkets()
        {
            if (true) //check AccessRight
            {
                return base.GetAllMarkets();
            }
        }
    }
}
