using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingAutofac.Models
{
    public class ConfigReader : IConfigReader
    {
        private string _fileName;
        public ConfigReader(string fileName)
        {
            _fileName = fileName;
        }
        public void Print()
        {
            Console.WriteLine($"File Name: {_fileName}");
        }
    }
}
