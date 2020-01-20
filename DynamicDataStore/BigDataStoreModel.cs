using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DynamicDataStore
{
    public class BigDataStoreModel
    {
        public BigDataStoreModel()
        {
            
        }
        public BigDataStoreModel(string className, string fieldName, object propValue, int currentRowNum)
        {
            BigDataStoreModel returnBigDataStoreModel = new BigDataStoreModel();
            Type returnBigDataStoreModelType = typeof(BigDataStoreModel);
            PropertyInfo propertyOfFieldName = returnBigDataStoreModelType.GetProperty(fieldName);
            propertyOfFieldName.SetValue(this, propValue, null);

            this.ClassName = className;
            this.Row = (byte)currentRowNum;

        }

        public Guid DataStoreIdentity { get; set; }
        public byte Row { get; set; }
        public string ClassName { get; set; }
        public int Int32_1 { get; set; }
        public int Int32_2 { get; set; }
        public string String_1 { get; set; }
        public string String_2 { get; set; }
        public string String_3 { get; set; }
    }
}
