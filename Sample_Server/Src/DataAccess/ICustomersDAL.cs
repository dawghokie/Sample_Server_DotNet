using Sample_Server.Src.Models;

namespace Sample_Server.Src.DataAccess
{
    public interface ICustomersDAL
    {
        Task<IEnumerable<Customers>> getAllCustomers();
    }
}

