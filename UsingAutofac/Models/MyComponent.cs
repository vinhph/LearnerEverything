using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingAutofac.Models
{
    public class MyComponent
    {
        public MyComponent() { /* ... */ }
        public MyComponent(ILogger logger) { /* ... */ }
        public MyComponent(ILogger logger, IConfigReader reader) { /* ... */ }
        public void Print()
        {
            Console.WriteLine("MyComponent");
        }
    }
}
