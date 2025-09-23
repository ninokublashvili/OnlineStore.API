using OnlineStore.Domain.Repositories.OrdrerItemRepository;
using OnlineStore.Domain.Repositories.OrdrerRepository;
using OnlineStore.Domain.Repositories.ProductCatalogRepository;
using OnlineStore.Domain.Repositories.UserRepository;
using OnlineStore.Domain.SeedWork;
using OnlineStore.Infrastructure.Persistence.Context;

namespace OnlineStore.Infrastructure.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProductDbContext _context;

        public IProductCatalogRepository ProductCatalogRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public IOrderItemRepository OrderItemRepository { get; }
        public IUserRepository UserRepository { get; }

        public UnitOfWork(
            ProductDbContext context,
            IProductCatalogRepository productCatalogRepository,
            IOrderRepository orderRepository,
            IOrderItemRepository orderItemRepository,
            IUserRepository userRepository)
        {
            _context = context;
            ProductCatalogRepository = productCatalogRepository;
            OrderRepository = orderRepository;
            OrderItemRepository = orderItemRepository;
            UserRepository = userRepository;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
