using MediatR;
using OnlineStore.Application.Shared.Mapper;

namespace OnlineStore.Application.ProductCatalog.Queries.GetProductById
{
    public class GetProductByIdQuery : MapFrom<GetProductByIdQueryModel>, IRequest<ProductByIdModel>
    {
        public int Id { get; set; }
    }
}
