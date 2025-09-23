using MediatR;
using OnlineStore.Application.Shared.Mapper;

namespace OnlineStore.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : MapFrom<CreateOrderModel>, IRequest<Unit>
    {
        public List<CreateOrderItem> Items { get; set; } = new();

        public class CreateOrderItem
        {
            public int ProductId { get; set; }
            public int Quantity { get; set; }
        }
    }
}
