using Sample_Server.Src.Models;

namespace Sample_Server.Src.BusinessLogic
{
    public interface IOrdersBL
    {
        Task<IEnumerable<Orders>> getAllOrders();
    }
}

