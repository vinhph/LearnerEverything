using System;
using System.Collections.Generic;

namespace DynamicDataStore
{
    public abstract class DynamicDataStore
    {
        private string _storeDefinition { get; set; }
        protected DynamicDataStore(string storeDefinition)
        {
            this._storeDefinition = storeDefinition;
        }
        public abstract Guid Save(object value);

        protected internal virtual Guid InternalSave(object value)
        {
            BigDataStoreTransferModel bigDataStoreTransferModel = value.ConvertToBigDataStoreModel();
            new BigDataStoreProvider().Insert(bigDataStoreTransferModel);
            return Guid.NewGuid();
        }
    }
}