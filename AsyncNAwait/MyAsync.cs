using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncNAwait
{
    public class MyAsync
    {
        private static Random _rnd;
        private static int index = 0;
        public void Run()
        {
            _rnd = new Random();

            //use normal Thread
            //Thread newThread1 = new Thread(() => ImageClick(1));
            //newThread1.Start();
            //Thread newThread2 = new Thread(() => ImageClick(2));
            //newThread2.Start();
            //Thread newThread3 = new Thread(() => ImageClick(3));
            //newThread3.Start();

            //use async, await
            //ButtonClick(1);
            //ButtonClick(2);
            //ButtonClick(3);

            //TestMultiTask();            
            //TestMultiTaskSynchronourlyType();
            //TestMultiTaskWhenAll();

            TestMultiTaskNotWhenAll();

            Console.WriteLine("End");
        }


        /// <summary>
        /// Cả func sẽ chạy bất đồng bộ trước
        /// nhưng từng hàm sẽ đợi nhau
        /// End
        /// After 5s
        /// step:1|index1
        /// After 5s
        /// step:2|index2
        /// After 5s
        /// step:3|index3
        /// </summary>
        private async void TestMultiTask()
        {
            string result1 = await AnSecondMethodAsync(1);
            Console.WriteLine(result1);
            string result2 = await AnSecondMethodAsync(2);
            Console.WriteLine(result2);
            string result3 = await AnSecondMethodAsync(3);
            Console.WriteLine(result3);
        }

        /// <summary>
        /// viết ntn thì coi như chạy đồng bộ
        /// khởi tạo task và đợi result
        /// After 5s
        /// step:1|index1
        /// After 5s
        /// step:2|index2
        /// After 5s
        /// step:3|index3
        /// End
        /// </summary>
        private async void TestMultiTaskSynchronourlyType()
        {
            Task<string> result1 = AnSecondMethodAsync(1);
            Console.WriteLine(result1.Result);
            Task<string> result2 = AnSecondMethodAsync(2);
            Console.WriteLine(result2.Result);
            Task<string> result3 = AnSecondMethodAsync(3);
            Console.WriteLine(result3.Result);
        }

        /// <summary>
        /// End
        /// After 5s
        /// step:2|index2
        /// step:1|index3
        /// step:3|index2
        /// </summary>
        private async void TestMultiTaskWhenAll()
        {
            Task<string> result1 = AnSecondMethodAsync(1);
            Task<string> result2 = AnSecondMethodAsync(2);
            Task<string> result3 = AnSecondMethodAsync(3);

            await Task.WhenAll(result1, result2, result3);

            Console.WriteLine(result2.Result);
            Console.WriteLine(result1.Result);
            Console.WriteLine(result3.Result);
        }

        /// <summary>
        /// After 5s
        /// step:2|index2
        /// step:1|index3
        /// step:3|index2
        /// End
        /// </summary>
        private async void TestMultiTaskNotWhenAll()
        {
            Task<string> result1 = AnSecondMethodAsync(1);
            Task<string> result2 = AnSecondMethodAsync(2);
            Task<string> result3 = AnSecondMethodAsync(3);

            //await Task.WhenAll(result1, result2, result3);

            Console.WriteLine(result1.Result);
            Console.WriteLine(result2.Result);
            Console.WriteLine(result3.Result);
        }

        private static async void ButtonClick(int step)
        {            
            string result = await AnMethodAsync(step);
            Console.WriteLine(result);
        }
        private static Task<string> AnMethodAsync(int step)
        {
            //var calculatingTime = _rnd.Next(5000);
            //Thread.Sleep(calculatingTime);
            //index++;
            //return Task.FromResult($"step:{step}|index{index}");
            return Task.Factory.StartNew(() =>
            {
                var calculatingTime = _rnd.Next(5000);
                Thread.Sleep(calculatingTime);
                index++;
                return $"step:{step}|index{index}";
            });
        }

        private static Task<string> AnSecondMethodAsync(int step)
        {
            return Task.Factory.StartNew(() =>
            {
                Thread.Sleep(5000);
                index++;
                return $"step:{step}|index{index}";
            });
        }

        private static void ImageClick(int step)
        {
            var calculatingTime = _rnd.Next(5000);
            Thread.Sleep(calculatingTime);
            index++;
            Console.WriteLine($"step:{step}|index{index}");
        }
    }
}
