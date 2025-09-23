using MediatR;
using OnlineStore.Application.Shared.Mapper;

namespace OnlineStore.Application.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQuery : MapFrom<GetOrderByIdQueryModel>, IRequest<OrderByIdModel>
    {
        public int Id { get; set; }
    }
}
