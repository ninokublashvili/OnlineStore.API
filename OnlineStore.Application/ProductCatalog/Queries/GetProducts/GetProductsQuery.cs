using MediatR;
using OnlineStore.Application.Shared.Base;
using OnlineStore.Application.Shared.Mapper;

namespace OnlineStore.Application.ProductCatalog.Queries.GetProducts
{
    public class GetProductsQuery : MapFrom<GetProductsQueryModel>, IRequest<PagedList<ProductsModel>>
    {
        public int PageNumber { get; init; }
        public int PageSize { get; init; }
    }
}
