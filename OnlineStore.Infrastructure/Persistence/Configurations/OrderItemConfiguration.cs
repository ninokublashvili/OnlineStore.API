using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Domain.Entities.OrderItemAggregate;

namespace OnlineStore.Infrastructure.Persistence.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> b)
        {
            b.ToTable("OrderItems", "dbo");
            b.HasKey(x => x.Id);

            b.Property(x => x.OrderId).IsRequired();
            b.Property(x => x.ProductId).IsRequired();
            b.Property(x => x.UnitPrice).HasPrecision(18, 2).IsRequired();
            b.Property(x => x.Quantity).IsRequired();

            b.HasIndex(x => new { x.OrderId, x.ProductId });

            b.HasOne(oi => oi.Product)
               .WithMany() 
               .HasForeignKey(oi => oi.ProductId)
               .IsRequired();
        }
    }
}