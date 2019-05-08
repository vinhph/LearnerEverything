using System;

namespace ServiceBusMessageQueue.Models
{
    public interface ICustomer
    {
        Guid CommandId { get; }
        DateTime Timestamp { get; }
        string CustomerId { get; }
        string HouseNumber { get; }
        string Street { get; }
        string City { get; }
        string State { get; }
        string PostalCode { get; }
    }
    public class Customer : ICustomer
    {
        public Guid CommandId { get; }
        public DateTime Timestamp { get; }
        public string CustomerId { get; set; }
        public string HouseNumber { get; }
        public string Street { get; }
        public string City { get; }
        public string State { get; }
        public string PostalCode { get; }
    }

}
