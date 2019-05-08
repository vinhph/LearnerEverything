using System;

namespace ServiceBusMessageQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            //BasicOfMassTransit.Run();
            new AdvanceOfMassTransit().Run();

            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
