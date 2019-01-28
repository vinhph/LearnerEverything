using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsingAutofac.Models;

namespace UsingAutofac.Bussiness
{
    public class MyPropertyInjection
    {
        public string UserName { get; set; }
        public IConfigReader ConfigReader { get; set; }

        public void Log()
        {
            Console.WriteLine(UserName);
            ConfigReader.Print();
        }
    }
}
