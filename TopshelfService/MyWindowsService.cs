using System;
using System.Timers;

namespace TopshelfService
{
    public class MyWindowsService
    {
        readonly Timer _timer;
        public void Start()
        {
            Console.WriteLine("Start");
        }

        public MyWindowsService()
        {
            _timer = new Timer(1000) { AutoReset = true };
            _timer.Elapsed += TimerOnElapsed;
            _timer.Start();
        }

        private void TimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("It is {0} and all is well", DateTime.Now);
        }

        public void Stop()
        {
            _timer.Stop();
            Console.WriteLine("Stop");
        }
    }
}
