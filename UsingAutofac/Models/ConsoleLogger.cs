using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingAutofac.Models
{
    public class ConsoleLogger : ILogger
    {
        public void Print()
        {
            Console.WriteLine("Logger");
        }
    }
}
