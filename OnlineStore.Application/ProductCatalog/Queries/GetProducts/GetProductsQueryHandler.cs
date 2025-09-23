using AutoMapper;
using MediatR;
using OnlineStore.Application.Shared.Base;
using OnlineStore.Domain.Entities.ProductAggregate;
using OnlineStore.Domain.SeedWork;

namespace OnlineStore.Application.ProductCatalog.Queries.GetProducts
{
    public sealed class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, PagedList<ProductsModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<PagedList<ProductsModel>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var query = _unitOfWork.ProductCatalogRepository.QueryNoTracking();
            query = query.OrderBy(p => p.Id);

            var paged = await PagedList<Product>.Create(_unitOfWork.ProductCatalogRepository, query, request.PageNumber,
                        request.PageSize, _mapper, cancellationToken);

            return _mapper.Map<PagedList<ProductsModel>>(paged);
        }
    }
}

