using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InjectedLearning
{
    public class MarketServiceDatabase : IMarketService
    {
        public virtual IEnumerable<Market> GetAllMarkets()
        {
            for (int i = 0;i < 3; i++)
            {
                yield return new Market() {ID = i, MarketName = "TQ" + i};
            }
        }
    }
}
