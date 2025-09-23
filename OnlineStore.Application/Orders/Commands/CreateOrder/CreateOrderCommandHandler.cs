using MediatR;
using Microsoft.AspNetCore.Http;
using OnlineStore.Application.Orders.Commands.CreateOrder;
using OnlineStore.Application.Services;
using OnlineStore.Application.Services.UserContext;
using OnlineStore.Common.Shared.Exceptions;
using OnlineStore.Domain.Entities.OrderAggregate;
using OnlineStore.Domain.SeedWork;
using System.Security.Claims;

namespace Application.Orders.Commands.CreateOrder;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Unit>
{
    private readonly UserContextService _userContextService;
    private readonly IUnitOfWork _unitOfWork;

    public CreateOrderCommandHandler(UserContextService userContextService, IUnitOfWork unitOfWork)
    {
        _userContextService = userContextService;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var currentUserId = _userContextService.GetCurrentUserId(); 

        var nowUtc = DateTime.UtcNow;
        var generator = new GuidOrderNumberGenerator();
        string orderNumber = generator.Generate();

        var order = Order.Create(orderNumber, nowUtc, currentUserId);

        foreach (var item in request.Items)
        {
            var product = await _unitOfWork.ProductCatalogRepository.GetByIdAsync(item.ProductId, cancellationToken)
                ?? throw new CustomException($"Product {item.ProductId} not found.");

            if (!product.IsActive)
                throw new CustomException($"Product {product.Id} is not active for sale.");

            if (!product.TryReserveStock(item.Quantity))
                throw new CustomException($"Insufficient stock for product {product.Id}.");

            order.AddItem(product, item.Quantity);


            _unitOfWork.ProductCatalogRepository.Update(product);
        }
        await _unitOfWork.OrderRepository.AddAsync(order, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
