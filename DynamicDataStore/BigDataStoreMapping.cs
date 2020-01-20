using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicDataStore
{
    public class BigDataStoreMapping
    {
        public string ClassName { get; set; }
        public string PropertyName { get; set; }
        public string PropertyType { get; set; }
        public string ColumnName { get; set; }
        public int RowNum { get; set; }
    }
}
