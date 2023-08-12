using Microsoft.AspNetCore.Mvc;
using Sample_Server.Src.BusinessLogic;
using Sample_Server.Src.Models;

namespace Sample_Server.Src.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private IOrdersBL OrdersBL { get; init; }

        private readonly ILogger<OrdersController> _logger;

        public OrdersController(ILogger<OrdersController> logger,
            IOrdersBL OrdersBL)
        {
            _logger = logger;
            this.OrdersBL = OrdersBL;
        }

        [HttpGet(Name = "orders")]
        public async Task<ActionResult> Get()
        {
            _logger.LogInformation("Getting all orders");
            try
            {
                IEnumerable<Orders> orders = await OrdersBL.getAllOrders();
                return Ok(orders);
            }
            catch (Exception e)
            {
                _logger.LogError("There was an error when calling getAllOrders | exception: ", e);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

