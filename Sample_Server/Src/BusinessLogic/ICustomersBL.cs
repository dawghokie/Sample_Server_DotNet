using Sample_Server.Src.Models;
namespace Sample_Server.Src.BusinessLogic
{
    public interface ICustomersBL
    {
        Task<IEnumerable<Customers>> getAllCustomers();
    }
}

