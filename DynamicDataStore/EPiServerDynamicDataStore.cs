using System;

namespace DynamicDataStore
{
    public class EPiServerDynamicDataStore : DynamicDataStore
    {
        public EPiServerDynamicDataStore(string storeDefinition) : base(storeDefinition)
        {
        }
        public override Guid Save(object value)
        {
            return this.InternalSave(value);
        }
    }
}