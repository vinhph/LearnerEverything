using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DynamicDataStore
{
    public static class BigDataStoreExtensions
    {        
        public static BigDataStoreTransferModel ConvertToBigDataStoreModel(this object value)
        {
            var bigDataStoreTransferModel = new BigDataStoreTransferModel(value.ToString());

            Type myType = value.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

            foreach (PropertyInfo prop in props)
            {
                if(prop.Name == "Id") continue;
                Mapping(value, prop, bigDataStoreTransferModel);
            }

            return bigDataStoreTransferModel;
        }

        private static void Mapping(object value, PropertyInfo prop, BigDataStoreTransferModel bigDataStoreTransferModel)
        {
            object propValue = prop.GetValue(value, null);
            bigDataStoreTransferModel.FillToDic(prop.Name, prop.PropertyType, propValue);         
        }
    }
}
