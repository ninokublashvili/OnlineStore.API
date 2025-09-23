using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Application.Orders.Commands.CreateOrder;
using OnlineStore.Application.Orders.Commands.DeleteOrder;
using OnlineStore.Application.Orders.Queries.GetOrderById;
using OnlineStore.Application.Orders.Queries.GetOrders;
using OnlineStore.Application.Shared.Base;

namespace OnlineStore.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : BaseController
    {
        public OrderController(IMapper mapper, IMediator mediator)
                              : base(mapper, mediator)
        {
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete("{id}", Name = nameof(DeleteOrder))]
        public async Task DeleteOrder([FromRoute] int id) =>
           await _mediator.Send(new DeleteOrderCommand { Id = id });

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(int), 200)]
        [HttpPost(Name = nameof(CreateOrder))]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            await _mediator.Send(command);
            return new NoContentResult();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{id}", Name = nameof(GetOrderById))]
        public async Task<OrderByIdModel> GetOrderById([FromRoute] int id) =>
          await _mediator.Send(new GetOrderByIdQuery { Id = id });

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet(Name = nameof(GetOrder))]
        public async Task<PagedList<OrdersModel>> GetOrder([FromQuery] GetOrdersQueryModel query, CancellationToken cancellationToken) =>
           await _mediator.Send(_mapper.Map<GetOrdersQuery>(query), cancellationToken);
    }
}
