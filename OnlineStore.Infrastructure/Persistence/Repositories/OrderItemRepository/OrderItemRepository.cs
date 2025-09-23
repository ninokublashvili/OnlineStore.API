using OnlineStore.Domain.Entities.OrderItemAggregate;
using OnlineStore.Domain.Repositories.OrdrerItemRepository;
using OnlineStore.Domain.Repositories.OrdrerRepository;
using OnlineStore.Infrastructure.Persistence.Context;
using OnlineStore.Infrastructure.Persistence.Repositories.Base;

namespace OnlineStore.Infrastructure.Persistence.Repositories.OrderItemRepository
{
    public class OrderItemRepository : GenericRepository<OrderItem, ProductDbContext>, IOrderItemRepository
    {
        public OrderItemRepository(ProductDbContext context)
            : base(context)
        {
        }
    }
}
