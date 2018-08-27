using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncNAwait
{
    class Program
    {
        private static Random _rnd;
        static void Main(string[] args)
        {
            //_rnd = new Random();

            //// cho phép tính 10 + 10
            //// thằng bé A bắt đầu tính              
            //Run("A", SumAsync(10, 10));

            //// thằng bé B bắt đầu tính 
            //Run("B", SumAsync(10, 10));

            //// thằng bé đếm thời gian
            //for (int i = 0; i < 60; i++)
            //{
            //    Thread.Sleep(50);
            //    Console.WriteLine(i);
            //}

            //MyAwait.Run();

            new MyAsync().Run();
            Console.Read();
        }

        private static async void Run(string name, Task<int> task)
        {
            var result = await task;
            Console.WriteLine(name + " has got the answer =" + result);
        }

        private static Task<int> SumAsync(int a, int b)
        {
            return Task.Factory.StartNew(() => Sum(a, b));
        }

        private static int Sum(int a, int b)
        {
            var calculatingTime = _rnd.Next(3000);
            Thread.Sleep(calculatingTime);

            return a + b;
        }
    }
}
