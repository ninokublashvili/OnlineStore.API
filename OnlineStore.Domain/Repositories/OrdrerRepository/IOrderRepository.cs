using OnlineStore.Domain.Entities.OrderAggregate;
using OnlineStore.Domain.Repositories.Base;

namespace OnlineStore.Domain.Repositories.OrdrerRepository
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
    }
}
