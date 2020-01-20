using System;
namespace DynamicDataStore
{
    public abstract class DynamicDataStoreFactory
    {
        public static DynamicDataStoreFactory Instance { get; set; }
        public abstract DynamicDataStore GetStore(Type type);
        public abstract DynamicDataStore CreateStore(Type type);
    }
}
