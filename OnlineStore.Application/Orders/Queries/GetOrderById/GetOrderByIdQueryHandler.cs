using MediatR;
using OnlineStore.Common.Shared.Exceptions;
using OnlineStore.Domain.SeedWork;

namespace OnlineStore.Application.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderByIdModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetOrderByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OrderByIdModel> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.OrderRepository
                .GetSingleAsync(o => o.Id == request.Id, cancellationToken)
                ?? throw new CustomException("Order not found");

            var result = new OrderByIdModel
            {
                OrderId = order.Id,
                OrderNumber = order.OrderNumber,
                Status = order.Status.ToString(),
                CreatedAtUtc = order.CreatedAtUtc,
                CancelledAtUtc = order.CancelledAtUtc,
                Total = order.Total
            };

            foreach (var i in order.Items)
            {
                result.Items.Add(new OrderByIdModel.OrderByIdItem
                {
                    ProductId = i.ProductId,
                    UnitPrice = i.UnitPrice,
                    Quantity = i.Quantity,
                    LineTotal = i.LineTotal
                });
            }

            return result;
        }
    }
}