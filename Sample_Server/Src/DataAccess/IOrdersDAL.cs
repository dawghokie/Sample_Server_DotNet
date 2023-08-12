using Sample_Server.Src.Models;

namespace Sample_Server.Src.DataAccess
{
    public interface IOrdersDAL
    {
        Task<IEnumerable<Orders>> getAllOrders();
    }
}

