using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain.Entities.ProductAggregate;
using OnlineStore.Domain.Repositories.ProductCatalogRepository;
using OnlineStore.Infrastructure.Persistence.Context;
using OnlineStore.Infrastructure.Persistence.Repositories.Base;

namespace OnlineStore.Infrastructure.Persistence.Repositories.ProductCatalogRepository
{
    public class ProductCatalogRepository : GenericRepository<Product, ProductDbContext>, IProductCatalogRepository
    {
        public ProductCatalogRepository(ProductDbContext context)
            : base(context)
        {

        }
        public IQueryable<Product> QueryNoTracking()
            => Context.Set<Product>().AsNoTracking();

        public Task<Product> GetByIdAsync(int id, CancellationToken ct = default)
            => Context.Set<Product>().AsNoTracking().FirstOrDefaultAsync(p => p.Id == id, ct);
    }
}
