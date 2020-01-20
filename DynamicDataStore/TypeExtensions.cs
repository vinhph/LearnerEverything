using System;

namespace DynamicDataStore
{
    public static class TypeExtensions
    {
        public static DynamicDataStore GetOrCreateStore(this Type type)
        {
            return DynamicDataStoreFactory.Instance.GetStore(type) ?? DynamicDataStoreFactory.Instance.CreateStore(type);
        }
    }
}