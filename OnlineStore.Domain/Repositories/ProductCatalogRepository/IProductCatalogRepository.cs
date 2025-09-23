using OnlineStore.Domain.Entities.ProductAggregate;
using OnlineStore.Domain.Repositories.Base;

namespace OnlineStore.Domain.Repositories.ProductCatalogRepository
{
    public interface IProductCatalogRepository : IGenericRepository<Product>
    {
        IQueryable<Product> QueryNoTracking();
        Task<Product> GetByIdAsync(int id, CancellationToken ct = default);
    }
}
