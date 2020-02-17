using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InjectedLearning
{
    public class CommerceSearchService : ICommerceSearchService
    {
        public static Injected<IMarketService> MarketService;
        private readonly ICurrentMarket _currentMarket;
        public static Injected<ICurrentMarket> MyCurrentMarket;

        public CommerceSearchService(IServiceFactory service)
        {
            _currentMarket = service.GetService<ICurrentMarket>();
        }
        public int GetProducts()
        {
            var currentMarket = this._currentMarket.GetCurrentMarket();
            var myCurrentMarket = MyCurrentMarket.Service.GetCurrentMarket();
            var allMarkets = MarketService.Service.GetAllMarkets();
            return allMarkets.Count() + currentMarket.ID;            
        }
    }
}
