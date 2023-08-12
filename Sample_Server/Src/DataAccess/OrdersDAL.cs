using Dapper;
using Npgsql;
using Sample_Server.Src.Models;
using Sample_Server.Src.Utils;

namespace Sample_Server.Src.DataAccess
{
    public class OrdersDAL : IOrdersDAL
    {
        private readonly ILogger<OrdersDAL> _logger;

        public OrdersDAL(ILogger<OrdersDAL> logger)
        {
            _logger = logger;
        }

        private static string GET_ORDERS_SQL =
            "SELECT * FROM qa_store.orders " +
            "INNER JOIN qa_store.customers on orders.customer_id_fk = customers.customer_id";

        public async Task<IEnumerable<Models.Orders>> getAllOrders()
        {
            var connectionString = ConfigUtils.GetConnectionString();
            var result = Enumerable.Empty<Orders>();

            // Using Connection Pools to manage connection lifecycle
            using (var connection = new NpgsqlConnection(connectionString))
            {
                _logger.LogInformation("Retrieving all orders from database");
                connection.Open();
                result = await connection.QueryAsync<Orders>(GET_ORDERS_SQL);
            }
            return result;

        }
    }
}

