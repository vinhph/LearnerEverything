using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingAutofac.Models
{
    public class StringWriter : TextWriter
    {
        public StringWriter()
        {

        }
        public override void Print()
        {
            Console.WriteLine("StringWriter.Print");
        }
    }
}
