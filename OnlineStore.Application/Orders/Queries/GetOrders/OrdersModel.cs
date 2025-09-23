using OnlineStore.Application.Shared.Mapper;
using OnlineStore.Domain.Entities.OrderAggregate;

namespace OnlineStore.Application.Orders.Queries.GetOrders
{
    public class OrdersModel : MapFrom<Order>
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; } = default!;
        public string Status { get; set; } = default!;
        public DateTime CreatedAtUtc { get; set; }
        public DateTime? CancelledAtUtc { get; set; }
        public decimal Total { get; set; }
        public List<OrdersListItem> Items { get; set; } = new();

        public class OrdersListItem
        {
            public int ProductId { get; set; }
            public decimal UnitPrice { get; set; }
            public int Quantity { get; set; }
            public decimal LineTotal { get; set; }
        }
    }
}
