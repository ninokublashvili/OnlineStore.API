using AutoMapper;
using MediatR;

namespace OnlineStore.API.Controllers
{
    public class BaseController
    {
        public readonly IMapper _mapper;
        public IMediator _mediator;
        public BaseController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
    }
}
