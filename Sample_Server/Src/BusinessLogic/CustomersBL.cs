using Sample_Server.Src.DataAccess;
using Sample_Server.Src.Models;

namespace Sample_Server.Src.BusinessLogic
{
    public class CustomersBL : ICustomersBL
    {
        private ICustomersDAL CustomersDAL { get; init; }

        private readonly ILogger<CustomersBL> _logger;

        public CustomersBL(ILogger<CustomersBL> logger,
            ICustomersDAL CustomersDAL)
        {
            _logger = logger;
            this.CustomersDAL = CustomersDAL;
        }

        public async Task<IEnumerable<Customers>> getAllCustomers()
        {
            var customerList = await CustomersDAL.getAllCustomers();
            _logger.LogInformation("Retrieved " + customerList.Count().ToString() + " customers");
            return customerList;
        }
    }
}

