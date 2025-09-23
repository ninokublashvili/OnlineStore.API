using AutoMapper;
using MediatR;
using OnlineStore.Application.ProductCatalog.Queries.GetProducts;
using OnlineStore.Application.Shared.Base;
using OnlineStore.Common.Shared.Exceptions;
using OnlineStore.Domain.Entities.ProductAggregate;
using OnlineStore.Domain.SeedWork;

namespace OnlineStore.Application.Orders.Queries.GetOrders
{
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, PagedList<OrdersModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetOrdersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PagedList<OrdersModel>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var query = (await _unitOfWork.OrderRepository.GetAllAsync(cancellationToken)).Where(x => x.UserId == request.UserId).ToList();

            var projected = query.Select(o => new OrdersModel
            {
                OrderId = o.Id,
                OrderNumber = o.OrderNumber,
                Status = o.Status.ToString(),
                CreatedAtUtc = o.CreatedAtUtc,
                CancelledAtUtc = o.CancelledAtUtc,
                Total = o.Total,

                Items = o.Items.Select(i => new OrdersModel.OrdersListItem
                {
                    ProductId = i.ProductId,
                    UnitPrice = i.UnitPrice,
                    Quantity = i.Quantity,
                    LineTotal = i.LineTotal
                }).ToList()
            });

            return _mapper.Map<PagedList<OrdersModel>>(projected);
        }
    }
}
