using System;

namespace DynamicDataStore
{
    public class EPiServerDynamicDataStoreFactory : DynamicDataStoreFactory, IDisposable
    {
        private string _initMessage { get; set; }
        public EPiServerDynamicDataStoreFactory(string initMessage)
        {
            _initMessage = initMessage;
        }
        public override DynamicDataStore GetStore(Type type)
        {
            string storeDefinition = "Get From web.config";
            return (DynamicDataStore)new EPiServerDynamicDataStore(storeDefinition);
        }

        public override DynamicDataStore CreateStore(Type type)
        {
            string storeDefinition = "Create From web.config";
            return (DynamicDataStore)new EPiServerDynamicDataStore(storeDefinition);
        }

        public void Dispose()
        {
            GC.SuppressFinalize((object)this);
        }
    }
}
