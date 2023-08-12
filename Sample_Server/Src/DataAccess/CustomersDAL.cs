using Dapper;
using Npgsql;
using Sample_Server.Src.Models;
using Sample_Server.Src.Utils;

namespace Sample_Server.Src.DataAccess
{
    public class CustomersDAL : ICustomersDAL
    {
        private readonly ILogger<CustomersDAL> _logger;

        public CustomersDAL(ILogger<CustomersDAL> logger)
        {
            _logger = logger;
        }

        private static string GET_CUSTOMERS_SQL =
            "SELECT customer_id, first_name, last_name, address FROM qa_store.customers";

        public async Task<IEnumerable<Customers>> getAllCustomers()
        {
            var connectionString = ConfigUtils.GetConnectionString();
            var result = Enumerable.Empty<Customers>();

            // Using Connection Pools to manage connection lifecycle
            using (var connection = new NpgsqlConnection(connectionString))
            {
                _logger.LogInformation("Retrieving all customers from database");
                connection.Open();
                result = await connection.QueryAsync<Customers>(GET_CUSTOMERS_SQL);
            }
            return result;
        }
    }
}