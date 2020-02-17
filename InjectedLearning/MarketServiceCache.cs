using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InjectedLearning
{
    public class MarketServiceCache : MarketServiceDatabase
    {
        private ISynchronizedObjectInstanceCache _cache;
        public MarketServiceCache(ISynchronizedObjectInstanceCache cache)
        {
            this._cache = cache;
        }
        public override IEnumerable<Market> GetAllMarkets()
        {
            //get cache
            var markets = base.GetAllMarkets();
            //set cache
            return markets;
        }
    }
}
