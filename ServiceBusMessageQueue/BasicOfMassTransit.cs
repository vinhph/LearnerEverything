using System;
using MassTransit;
using ServiceBusMessageQueue.Consumers;
using ServiceBusMessageQueue.Models;

namespace ServiceBusMessageQueue
{
    public static class BasicOfMassTransit
    {
        public static void Run()
        {
            IServiceBus busCustomer = ServiceBusFactory.New(sbc =>
            {
                sbc.UseMsmq(configurator => configurator.VerifyMsmqConfiguration());
                sbc.ReceiveFrom("msmq://cl-vinhpham/HardWorkingQueue");//msmq://localhost/delonghiService
                sbc.Subscribe(subs =>
                {
                    subs.Consumer<CustomerConsumer>();
                });
            });

            IServiceBus busStudent = ServiceBusFactory.New(sbc =>
            {
                sbc.UseMsmq(configurator => configurator.VerifyMsmqConfiguration());
                sbc.ReceiveFrom("msmq://cl-vinhpham/HardWorkingQueue");//msmq://localhost/delonghiService
                sbc.Subscribe(subs =>
                {
                    subs.Consumer<StudentConsumer>();
                });
            });

            PublishCustomerMessage(busCustomer, "1");
            PublishCustomerMessage(busCustomer, "2");
            PublishCustomerMessage(busCustomer, "3");

            PublishStudentMessage(busStudent, "Back Khoa");
            PublishStudentMessage(busStudent, "NewYork");
            PublishStudentMessage(busStudent, "NN1");

            Console.WriteLine("Push done, wait a minuste");
            Console.ReadLine();

            busCustomer.Dispose();
            busStudent.Dispose();
        }
        public static void PublishCustomerMessage(IServiceBus bus, string customerId)
        {
            bus.Publish(new Customer()
            {
                CustomerId = customerId
            });
        }
        public static void PublishStudentMessage(IServiceBus bus, string university)
        {
            bus.Publish(new Student()
            {
                University = university
            });
        }
    }
}
