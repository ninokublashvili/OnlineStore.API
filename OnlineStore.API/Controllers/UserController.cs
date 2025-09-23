using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Application.ProductCatalog.Commands.CreateProduct;
using OnlineStore.Application.Users.Commands.CreateUser;
using OnlineStore.Application.Users.Queries.LogInUser;

namespace OnlineStore.API.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public UserController(IMediator mediator,
                              IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(int), 200)]
        [HttpPost(Name = nameof(UserRegistration))]
        public async Task UserRegistration([FromBody] CreateUserCommandModel request) =>
           await _mediator.Send(_mapper.Map<CreateUserCommand>(request));

        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(int), 200)]
        [HttpPost("LogIn")]
        public async Task<IActionResult> UserLogIn([FromBody] LogInUserQueryModel query)
        {
            var requestModel = _mapper.Map<LogInUserQuery>(query);
            var userResult = await _mediator.Send(requestModel);
            return Ok(userResult);
        }
    }
}
