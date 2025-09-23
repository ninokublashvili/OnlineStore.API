using OnlineStore.Application.Shared.Mapper;
using OnlineStore.Domain.Entities.OrderAggregate;

namespace OnlineStore.Application.Orders.Queries.GetOrderById
{
    public class OrderByIdModel : MapFrom<Order>
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; } = default!;
        public string Status { get; set; } = default!;
        public DateTime CreatedAtUtc { get; set; }
        public DateTime? CancelledAtUtc { get; set; }
        public decimal Total { get; set; }
        public List<OrderByIdItem> Items { get; set; } = new();

        public class OrderByIdItem
        {
            public int ProductId { get; set; }
            public decimal UnitPrice { get; set; }
            public int Quantity { get; set; }
            public decimal LineTotal { get; set; }
        }
    }
}
