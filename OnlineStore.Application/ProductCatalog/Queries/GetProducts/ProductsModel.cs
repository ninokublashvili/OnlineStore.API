using OnlineStore.Application.Shared.Mapper;
using OnlineStore.Domain.Entities.ProductAggregate;

namespace OnlineStore.Application.ProductCatalog.Queries.GetProducts
{
    public class ProductsModel : MapFrom<Product>
    {
        public int Id { get; init; }
        public string Name { get; init; } 
        public string Sku { get; init; }
        public decimal Price { get; init; }
        public int StockQuantity { get; init; }
        public bool IsActive { get; init; }
    }
}
