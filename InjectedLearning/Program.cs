using System;
using StructureMap;
namespace InjectedLearning
{
    class Program
    {
        private static IContainer Container { get; set; }
        static void Main(string[] args)
        {
            //structuremap
            var container = new Container(_ =>
            {
                _.For<ISynchronizedObjectInstanceCache>().Use<RemoteCacheSynchronization>();
                _.For<IObjectInstanceCache>().Use<LocalCache>(); 
                _.For<IServiceFactory>().Use<ServiceFactory>();
                _.For<IMarketService>().Use<MarketAccessRightsMarketService>();
                _.For<ICurrentMarket>().Use<CurrentMarket>();
                _.For<ICommerceSearchService>().Use<CommerceSearchService>();
            });
            ServiceLocator.SetLocator(new StructureMapServiceLocator(container));
            var commerceSearchService = container.GetInstance<ICommerceSearchService>();
            Console.WriteLine(commerceSearchService.GetProducts());
            Console.Read();
        }
    }
}
