using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Common.Shared.Exceptions;
using OnlineStore.Domain.SeedWork;

namespace OnlineStore.Application.ProductCatalog.Commands.DecreaseStock
{
    public class DecreaseStockCommandHandler : IRequestHandler<DecreaseStockCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DecreaseStockCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DecreaseStockCommand request, CancellationToken ct)
        {
            var product = await _unitOfWork.ProductCatalogRepository.GetByIdAsync(request.Id, ct)
                         ?? throw new CustomException("Product not found");

            if (!product.IsActive)
                throw new CustomException("Product is not active for sale.");

            if (!product.TryReserveStock(request.Quantity))
                throw new CustomException("Insufficient stock.");

            _unitOfWork.ProductCatalogRepository.Update(product);

            try
            {
                await _unitOfWork.SaveChangesAsync(ct);
                return Unit.Value;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new CustomException("Concurrency conflict. Please retry.");
            }
        }
    }
}
