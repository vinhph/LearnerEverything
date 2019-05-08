using Autofac;
using MassTransit;
using ServiceBusMessageQueue.AutofacModule;
using ServiceBusMessageQueue.Consumers;
using ServiceBusMessageQueue.Models;

namespace ServiceBusMessageQueue
{
    public class AdvanceOfMassTransit
    {
        private ContainerBuilder builder;

        public static IContainer container;
        public void Run()
        {
            QueueUtility.QueueMessage(new Student()
            {
                University = "Ngoai ngu 1"
            });

            QueueUtility.QueueMessage(new Student()
            {
                University = "Bach khoa 2"
            });

            QueueUtility.QueueMessage(new Student()
            {
                University = "Quoc gia 3"
            });

            QueueUtility.QueueMessage(new Customer()
            {
                CustomerId = "ID1"
            });

            QueueUtility.QueueMessage(new Customer()
            {
                CustomerId = "ID2"
            });

            builder = new ContainerBuilder();
            builder.RegisterModule(new RegistrationModule(true));

            container = builder.Build();

            var bus = container.Resolve<IServiceBus>();
            
        }
    }
}
