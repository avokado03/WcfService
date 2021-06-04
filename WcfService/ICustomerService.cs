using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace WcfService
{
    [ServiceContract]
    public interface ICustomerService
    {
        [OperationContract]
        List<Customer> GetCustomers();

        [OperationContract]
        List<Order> GetOrders(int customerId);
    }

    [DataContract]
    public class Customer
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }

        [DataMember(Order = 2)]
        public string Name { get; set; }

        [DataMember(Order = 3)]
        public string Surname { get; set; }

        [DataMember(Order = 4)]
        public int YearOfBirth { get; set; }
    }

    [DataContract]
    public class Order
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }

        [DataMember(Order = 2)]
        public string Title { get; set; }
        
        [DataMember(Order = 3)]
        public int CustomerId { get; set; }

        [DataMember(Order = 4)]
        public decimal Price { get; set; }

        [DataMember(Order = 5)]
        public int Count { get; set; }
    }
}
