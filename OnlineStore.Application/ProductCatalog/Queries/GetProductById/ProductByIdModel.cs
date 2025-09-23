using OnlineStore.Application.Shared.Mapper;
using OnlineStore.Domain.Entities.ProductAggregate;

namespace OnlineStore.Application.ProductCatalog.Queries.GetProductById
{
    public class ProductByIdModel : MapFrom<Product>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sku { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public bool IsActive { get; set; }
    }
}
