using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncNAwait
{
    class MyAwait
    {
        public static async void Run()
        {
            Task myTask = Task.Factory.StartNew(DownloadString);

            //await myTask;
            
            Console.WriteLine("End");
        }

        private static void DownloadString()
        {
            Thread.Sleep(5000);
            Console.WriteLine("vinh");            
        }
    }
}
