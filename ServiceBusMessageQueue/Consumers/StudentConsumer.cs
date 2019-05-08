using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassTransit;
using ServiceBusMessageQueue.Models;

namespace ServiceBusMessageQueue.Consumers
{
    public class StudentConsumer : Consumes<Student>.Context
    {
        public void Consume(IConsumeContext<Student> message)
        {
            Console.WriteLine($"Student - University : {message.Message.University}");
        }
    }
}
