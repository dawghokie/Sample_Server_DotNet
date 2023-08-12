using Microsoft.AspNetCore.Mvc;
using Sample_Server.Src.BusinessLogic;
using Sample_Server.Src.Models;

namespace Sample_Server.Src.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private ICustomersBL CustomersBL { get; init; }

        private readonly ILogger<CustomersController> _logger;

        public CustomersController(ILogger<CustomersController> logger,
            ICustomersBL CustomersBL)
        {
            _logger = logger;
            this.CustomersBL = CustomersBL;
        }

        [HttpGet(Name = "customers")]
        public async Task<ActionResult> Get()
        {
            _logger.LogInformation("Geting all customers");
            try
            {
                IEnumerable<Customers> customers = await CustomersBL.getAllCustomers();
                return Ok(customers);
            }
            catch (Exception e)
            {
                _logger.LogError("There was an error when calling getAllCustomers | exception: ", e);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}