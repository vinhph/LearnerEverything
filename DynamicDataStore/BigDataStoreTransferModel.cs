using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DynamicDataStore
{
    public class BigDataStoreTransferModel
    {
        private string _className { get; set; }
        public BigDataStoreTransferModel(string className)
        {
            Models = new List<BigDataStoreModel>();
            BigDataStoreMappings = new List<BigDataStoreMapping>();
            _className = className;            
        }
        public List<BigDataStoreModel> Models { get; set; }
        public List<BigDataStoreMapping> BigDataStoreMappings { get; set; }

        public void FillToDic(string propertyName, Type propertyType, object propValue)
        {
            string fieldName = GetColumnName(propertyType.Name, out int currentRowNum);
            Models.Add(new BigDataStoreModel(_className, fieldName, propValue, currentRowNum));
            BigDataStoreMappings.Add(new BigDataStoreMapping()
            {
                ClassName = _className,
                ColumnName = fieldName,
                PropertyType = propertyType.Name,
                PropertyName = propertyName,
                RowNum = currentRowNum
            });
        }

        private string GetColumnName(string columnType, out int currentRowNum)
        {
            currentRowNum = 1;
            string fieldName = columnType + "_1";
            var bigDataStoreMappingWithType = BigDataStoreMappings.Where(x => x.PropertyType == columnType).ToList();
            if (bigDataStoreMappingWithType.Count > 0)
            {
                //get max row
                var maxRow = bigDataStoreMappingWithType.OrderByDescending(i => i.RowNum).FirstOrDefault()?.RowNum;
                var bigDataStoreMappingWithTypeMaxRow = BigDataStoreMappings.Where(x => x.PropertyType == columnType && x.RowNum == (maxRow ?? 1)).ToList();
                int maxColumnNameOfType = GetMaxColumnNameOfType(columnType);
                for (int i = 1; i <= maxColumnNameOfType; i++)
                {
                    if (!bigDataStoreMappingWithTypeMaxRow.Exists(x => x.ColumnName == (columnType + "_" + i)))
                    {
                        currentRowNum = maxRow ?? 1;
                        fieldName = columnType + "_" + i;
                        return fieldName;
                    }
                }
                currentRowNum = (maxRow ?? 1) + 1;
                fieldName = columnType + "_1";
                return fieldName;
            }  
            return fieldName;
        }

        private int GetMaxColumnNameOfType(string columnType)
        {
            IList<PropertyInfo> props = new List<PropertyInfo>(typeof(BigDataStoreModel).GetProperties());
            int maxColumnNameOfType = 0;
            foreach (PropertyInfo prop in props)
            {
                if (prop.Name.Contains(columnType+"_"))
                {
                    maxColumnNameOfType++;
                }
            }

            return maxColumnNameOfType;
        }
    }

    public class Row
    {
        public Dictionary<string, object> Fields { get; set; }

        public Row()
        {
            Fields = new Dictionary<string, object>()
            {
                { "int1", null },
                { "int2", null },
                { "str1", null },
                { "str2", null },
                { "str3", null }
            };
        }

        public void Set(string field, object obj)
        {
            Fields[field] = obj;
        }
    }
}
