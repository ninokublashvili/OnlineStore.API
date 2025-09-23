using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain.Entities.ProductAggregate;
using OnlineStore.Domain.Repositories.Base;
using System.Linq.Expressions;

namespace OnlineStore.Infrastructure.Persistence.Repositories.Base
{
    public class GenericRepository<T, DC> : IGenericRepository<T> where T : class
            where DC : DbContext
    {
        public readonly DC Context;

        public GenericRepository(DC context)
        {
            Context = context;
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await Context.AddAsync(entity, cancellationToken);
        }

        public async Task<int> CountAsync(IQueryable<T> data, CancellationToken cancellationToken = default)
        {
            return await data.AsNoTracking().CountAsync(cancellationToken);
        }

        public virtual async Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await Context.Set<T>().ToListAsync(cancellationToken);
        }

        public virtual async Task<List<T>> ToListAsync(IQueryable<T> data, CancellationToken cancellationToken = default)
        {
            return await data.AsNoTracking().ToListAsync(cancellationToken);
        }


        public virtual async Task<T> GetSingleAsync(Expression<Func<T, bool>> @where, CancellationToken cancellationToken = default)
        {
            return await Context.Set<T>().FirstOrDefaultAsync(where, cancellationToken);
        }

        public virtual void Update(T entity)
        {
            Context.Update(entity);
        }
        
        public Task<bool> ExistsBySkuExceptIdAsync(string sku, int excludeId, CancellationToken ct = default)
            => Context.Set<Product>().AsNoTracking().AnyAsync(p => p.Sku == sku && p.Id != excludeId, ct);

    }
}