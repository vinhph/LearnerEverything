namespace DynamicDataStore
{
    public class DataInitialization
    {
        public void Initialize()
        {
            DynamicDataStoreFactory.Instance = (DynamicDataStoreFactory)new EPiServerDynamicDataStoreFactory("Init");            
        }
    }
}
