using System;
using MassTransit;
using ServiceBusMessageQueue.Models;

namespace ServiceBusMessageQueue.Consumers
{
    public class CustomerConsumer : Consumes<Customer>.Context
    {
        public void Consume(IConsumeContext<Customer> message)
        {
            Console.WriteLine($"Customer - CustomerId : {message.Message.CustomerId}");
        }
    }
}
