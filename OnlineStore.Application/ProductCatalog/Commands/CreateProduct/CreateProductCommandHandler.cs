using MediatR;
using OnlineStore.Common.Shared.Exceptions;
using OnlineStore.Domain.Entities.ProductAggregate;
using OnlineStore.Domain.SeedWork;

namespace OnlineStore.Application.ProductCatalog.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var sku = request.SKU.Trim().ToUpperInvariant();

            var existing = await _unitOfWork.ProductCatalogRepository
                .GetSingleAsync(x => x.Sku == sku, cancellationToken); 

            if (existing is not null)
                throw new CustomException($"SKU '{sku}' already exists.");

            var product = Product.Create(
                name: request.Name,
                sku: sku,
                price: request.Price,
                stock: request.StockQuantity);

            await _unitOfWork.ProductCatalogRepository.AddAsync(product, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

    }
}

