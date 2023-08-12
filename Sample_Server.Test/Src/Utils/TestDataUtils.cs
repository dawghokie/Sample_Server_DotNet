using Sample_Server.Src.Models;

namespace Sample_Server.Test.Src.Utils
{
    // Simple manner of getting test data for customers and orders
    // Improve logic for more robust testing (less duplicate code)
	public static class TestDataUtils
	{
        public static IEnumerable<Customers> getTestCustomer(Guid guid)
        {
            IEnumerable<Customers> customer = new[]
            {
                new Customers()
                {
                    Customer_Id = guid,
                    Address = "1234 Reston, VA 22131",
                    First_Name = "Bill",
                    Last_Name = "Murray",
                }
            };

            return customer;
        }

        public static IEnumerable<Customers> getTestCustomers(Guid guid1, Guid guid2)
        {
            IEnumerable<Customers> customer = new[]
            {
                new Customers()
                {
                    Customer_Id = guid1,
                    Address = "1234 Reston, VA 22131",
                    First_Name = "Bill",
                    Last_Name = "Murray",
                },
                new Customers()
                {
                    Customer_Id = guid2,
                    Address = "4321 Blacksburg, VA 11223",
                    First_Name = "Tyrod",
                    Last_Name = "Taylor",
                },
            };

            return customer;
        }

        public static IEnumerable<Orders> getTestOrder(Guid guid1, Guid guid2)
        {
            IEnumerable<Orders> order = new[]
            {
                new Orders()
                {
                    Customer_Id = guid1,
                    Address = "1234 Reston, VA 22131",
                    First_Name = "Bill",
                    Last_Name = "Murray",
                    Order_Id = guid2,
                    Item_Name = "",
                    Cost = 1
                }
            };

            return order;
        }

        public static IEnumerable<Orders> getTestOrders(Guid guid1, Guid guid2,
            Guid guid3, Guid guid4)
        {
            IEnumerable<Orders> order = new[]
            {
                new Orders()
                {
                    Customer_Id = guid1,
                    Address = "1234 Reston, VA 22131",
                    First_Name = "Bill",
                    Last_Name = "Murray",
                    Order_Id = guid2,
                    Item_Name = "",
                    Cost = 1
                },
                new Orders()
                {
                    Customer_Id = guid3,
                    Address = "1234 Reston, VA 22131",
                    First_Name = "Bill",
                    Last_Name = "Murray",
                    Order_Id = guid4,
                    Item_Name = "",
                    Cost = 1
                }
            };

            return order;
        }
    }
}

