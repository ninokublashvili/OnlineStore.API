using MediatR;
using OnlineStore.Common.Shared.Exceptions;
using OnlineStore.Domain.SeedWork;

namespace OnlineStore.Application.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteOrderCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.OrderRepository
                .GetSingleAsync(x => x.Id == request.Id, cancellationToken)
                ?? throw new CustomException("Order Not Found");

            order.Cancel();

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
