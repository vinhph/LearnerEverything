using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnerEverything
{
    class Program
    {
        static void Main(string[] args)
        {
            string test = "vinh pham huu";
            test = "*" + string.Join(" *", test.Split(' '));
            Console.WriteLine(test);
            Console.ReadLine();
        }
    }
}
