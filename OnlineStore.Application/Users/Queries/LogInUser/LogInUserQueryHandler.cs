using MediatR;
using OnlineStore.Application.Services;
using OnlineStore.Application.Services.JWTService;
using OnlineStore.Domain.SeedWork;

namespace OnlineStore.Application.Users.Queries.LogInUser
{
    public class LogInUserQueryHandler : IRequestHandler<LogInUserQuery, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtService _jwtService;
        public LogInUserQueryHandler(IUnitOfWork unitOfWork,
                                     IJwtService jwtService)
        {
            _unitOfWork = unitOfWork;
            _jwtService = jwtService;
        }
        public async Task<string> Handle(LogInUserQuery request, CancellationToken cancellationToken)
        {
            var getUser = await _unitOfWork.UserRepository.GetSingleAsync(x => x.UserName == request.UserName, cancellationToken);

            var hashedInput = HashPassword.GenerateHashedPassword(request.Password);
            if (getUser == null || !(request.UserName == getUser.UserName && hashedInput == getUser.Password))
            {
                throw new Exception("Invalid username or password.");
            }

            var userToken = _jwtService.GenerateUserToken(getUser.UserName, getUser.Id, getUser.Role);


            return userToken;
        }
    }
}
