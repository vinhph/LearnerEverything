using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnerEverything
{
    class Program
    {
        static void Main(string[] args)
        {
            //string test = "vinh pham huu";
            //test = "*" + string.Join(" *", test.Split(' '));
            //Console.WriteLine(test);
            //Console.ReadLine();

            string text = System.IO.File.ReadAllText(@"d:\Download\test.txt");
            text += DateTime.Now.ToString();
            System.IO.File.WriteAllText(@"d:\Download\test.txt", text);

            Console.WriteLine("done");
        }
    }
}
