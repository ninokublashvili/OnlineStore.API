using OnlineStore.Domain.Repositories.OrdrerItemRepository;
using OnlineStore.Domain.Repositories.OrdrerRepository;
using OnlineStore.Domain.Repositories.ProductCatalogRepository;
using OnlineStore.Domain.Repositories.UserRepository;
using OnlineStore.Domain.SeedWork.Base;

namespace OnlineStore.Domain.SeedWork
{
    public interface IUnitOfWork : IGenericUnitOfWork
    {
        IProductCatalogRepository ProductCatalogRepository { get; }
        IOrderRepository OrderRepository { get; }
        IOrderItemRepository OrderItemRepository { get; }
        IUserRepository UserRepository { get; }
    }
}