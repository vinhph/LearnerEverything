using System;

namespace ServiceBusMessageQueue
{
    class Program
    {
        //msmq://cl-vinhpham/private$/HardWorkingQueue
        static void Main(string[] args)
        {
            BasicOfMassTransit.Run();

            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
