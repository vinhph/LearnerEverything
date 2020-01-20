using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicDataStore
{
    public class BigDataStoreProvider
    {
        public Guid Insert(BigDataStoreTransferModel bigDataStoreTransferModel)
        {
            return Guid.NewGuid();
        }
    }
}
