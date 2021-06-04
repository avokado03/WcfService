using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace WcfService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.
    public class Service1 : IService1
    {
        private const string CONNECTION_NAME = "TradeCompany";
        private string _connectionString;

        public Service1()
        {
            _connectionString = ConfigurationManager.ConnectionStrings[CONNECTION_NAME].ConnectionString;
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
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
