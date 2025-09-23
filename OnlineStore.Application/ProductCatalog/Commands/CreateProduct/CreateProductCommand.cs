using MediatR;
using OnlineStore.Application.Shared.Mapper;

namespace OnlineStore.Application.ProductCatalog.Commands.CreateProduct
{
    public class CreateProductCommand : MapFrom<CreateProductModel>, IRequest<Unit>
    {
        public string Name { get; set; }
        public string SKU { get; set; } 
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
    }
}
