using OnlineStore.Domain.Entities.OrderAggregate;
using OnlineStore.Domain.Repositories.OrdrerRepository;
using OnlineStore.Infrastructure.Persistence.Context;
using OnlineStore.Infrastructure.Persistence.Repositories.Base;

namespace OnlineStore.Infrastructure.Persistence.Repositories.OrderRepository
{
    public class OrderRepository : GenericRepository<Order, ProductDbContext>, IOrderRepository
    {
        public OrderRepository(ProductDbContext context)
            : base(context)
        {
        }

    }
}
