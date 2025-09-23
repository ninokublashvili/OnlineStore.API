using MediatR;
using OnlineStore.Application.Shared.Mapper;
using OnlineStore.Domain.Entities.User;

namespace OnlineStore.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand :MapFrom<CreateUserCommandModel>, IRequest<ResultModel>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public AppRole Role { get; init; }
    }
}
