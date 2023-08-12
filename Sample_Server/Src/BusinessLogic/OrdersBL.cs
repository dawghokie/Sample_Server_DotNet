using Sample_Server.Src.DataAccess;
using Sample_Server.Src.Models;

namespace Sample_Server.Src.BusinessLogic
{
    public class OrdersBL : IOrdersBL
    {
        private IOrdersDAL OrdersDAL { get; init; }

        private readonly ILogger<OrdersBL> _logger;

        public OrdersBL(ILogger<OrdersBL> logger,
            IOrdersDAL OrdersDAL)
        {
            _logger = logger;
            this.OrdersDAL = OrdersDAL;
        }

        public async Task<IEnumerable<Orders>> getAllOrders()
        {
            var ordersList = await OrdersDAL.getAllOrders();
            _logger.LogInformation("Retrieved " + ordersList.Count().ToString() + " orders");
            return ordersList;
        }

    }
}

