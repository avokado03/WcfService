using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace WcfService
{
    public class CustomerService : ICustomerService
    {
        private const string CONNECTION_NAME = "TradeCompany";
        private string _connectionString;

        public CustomerService()
        {
            _connectionString = ConfigurationManager.ConnectionStrings[CONNECTION_NAME].ConnectionString;
        }

        public List<Order> GetOrders(int customerId)
        {
            var orderList = new List<Order>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var orderCommand = new SqlCommand("SELECT * FROM Orders WHERE CustomerId = @CustomerId", connection);
                orderCommand.Parameters.Add(new SqlParameter("@CustomerId", customerId));
                connection.Open();
                var reader = orderCommand.ExecuteReader();
                while(reader.Read())
                {
                    orderList.Add(new Order
                    {
                        Id = (int)reader["Id"],
                        Title = reader["Title"].ToString(),
                        CustomerId = (int)reader["CustomerId"],
                        Price = (decimal)reader["Price"],
                        Count = (int)reader["Count"]
                    });
                }
            }
            return orderList;
        }

        public List<Customer> GetCustomers()
        {
            var customersList = new List<Customer>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var customersCommand = new SqlCommand("SELECT * FROM Customers", connection);
                connection.Open();
                var reader = customersCommand.ExecuteReader();
                while(reader.Read())
                {
                    customersList.Add(new Customer
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"].ToString(),
                        Surname = reader["Surname"].ToString(),
                        YearOfBirth = (int)reader["YearOfBirth"]
                    });
                }
            }
            return customersList;
        }
    }
}
