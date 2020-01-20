using System;

namespace DynamicDataStore
{    
    public class RestrictPromotionStore
    {
        public Guid Id { get; set; }
        public int PromotionId { get; set; }
        public int Age1 { get; set; }
        public int Age2 { get; set; }
        public int Age3 { get; set; }
        public int Age4 { get; set; }
        public string Category { get; set; }
    }
}
