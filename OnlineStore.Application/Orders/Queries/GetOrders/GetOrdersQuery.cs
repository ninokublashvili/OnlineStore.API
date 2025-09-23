using MediatR;
using OnlineStore.Application.Shared.Base;
using OnlineStore.Application.Shared.Mapper;

namespace OnlineStore.Application.Orders.Queries.GetOrders
{
    public class GetOrdersQuery : MapFrom<GetOrdersQueryModel>, IRequest<PagedList<OrdersModel>>
    {
        public int UserId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; } 

        public class Item
        {
            public int OrderId { get; set; }
            public string OrderNumber { get; set; } = default!;
            public string Status { get; set; } = default!;
            public decimal Total { get; set; }
            public DateTime CreatedAtUtc { get; set; }
        }
    }
}