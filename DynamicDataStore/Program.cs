using System;

namespace DynamicDataStore
{
    class Program
    {
        static void Main(string[] args)
        {
            new DataInitialization().Initialize();
            DynamicDataStore store = typeof(RestrictPromotionStore).GetOrCreateStore();
            var newID = store.Save(new RestrictPromotionStore()
            {
                PromotionId = 111,
                Age1 = 1,
                Age2 = 2,
                Age3 = 3,
                Age4 = 4,
                Category = "Coffee"
            });
            Console.Write(newID);
            Console.Read();
        }
    }
}
