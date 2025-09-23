using MediatR;
using OnlineStore.Common.Shared.Exceptions;
using OnlineStore.Domain.SeedWork;

namespace OnlineStore.Application.ProductCatalog.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.ProductCatalogRepository
                .GetSingleAsync(p => p.Id == request.Id, cancellationToken)
                ?? throw new CustomException("Product Not Found");

            var normalizedSku = request.SKU?.Trim().ToUpperInvariant();

            if (normalizedSku is not null &&
                !string.Equals(product.Sku, normalizedSku, StringComparison.OrdinalIgnoreCase))
            {
                var skuExists = await _unitOfWork.ProductCatalogRepository
                    .ExistsBySkuExceptIdAsync(normalizedSku, request.Id, cancellationToken);

                if (skuExists)
                    throw new InvalidOperationException($"SKU '{normalizedSku}' already exists.");
            }


            _unitOfWork.ProductCatalogRepository.Update(product);
            product.Update(request.SKU, request.Price, request.StockQuantity, request.IsActive);

            _unitOfWork.ProductCatalogRepository.Update(product);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return product.Id;
        }
    }
}