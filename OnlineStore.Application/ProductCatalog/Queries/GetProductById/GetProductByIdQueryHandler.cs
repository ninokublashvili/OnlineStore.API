using MediatR;
using OnlineStore.Domain.SeedWork;

namespace OnlineStore.Application.ProductCatalog.Queries.GetProductById
{
    public sealed class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductByIdModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetProductByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductByIdModel> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.ProductCatalogRepository
                .GetSingleAsync(x => x.Id == request.Id, cancellationToken);

            if (product is null)
                throw new KeyNotFoundException($"Product with Id '{request.Id}' was not found.");

            return new ProductByIdModel
            {
                Id = product.Id,
                Name = product.Name,
                Sku = product.Sku,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                IsActive = product.IsActive
            };
        }
    }
}

