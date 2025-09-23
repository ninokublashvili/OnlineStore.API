using MediatR;
using OnlineStore.Application.Shared.Mapper;

namespace OnlineStore.Application.Users.Queries.LogInUser
{
    public class LogInUserQuery : MapFrom<LogInUserQueryModel>, IRequest<string>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
