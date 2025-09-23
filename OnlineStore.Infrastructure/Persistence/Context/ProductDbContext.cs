using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain.Entities.OrderAggregate;
using OnlineStore.Domain.Entities.OrderItemAggregate;
using OnlineStore.Domain.Entities.ProductAggregate;
using OnlineStore.Domain.Entities.User;

namespace OnlineStore.Infrastructure.Persistence.Context
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductDbContext).Assembly);
        }
    }
}
