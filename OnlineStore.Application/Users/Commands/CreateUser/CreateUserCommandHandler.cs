using MediatR;
using OnlineStore.Application.Services;
using OnlineStore.Domain.SeedWork;

namespace OnlineStore.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ResultModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResultModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetSingleAsync(x => x.UserName.ToUpper() == request.UserName.ToUpper(), cancellationToken);
            if (user != null)
            {
                throw new Exception("A user with the same username already exists.");
            }

            try
            {
                var hashedPassword = HashPassword.GenerateHashedPassword(request.Password);
                var entity = OnlineStore.Domain.Entities.User.Users.RegisterUser(request.FirstName,
                                                                    request.LastName,
                                                                    request.UserName,
                                                                    hashedPassword,
                                                                    request.Role);

                await _unitOfWork.UserRepository.AddAsync(entity, cancellationToken);

                await _unitOfWork.SaveChangesAsync(cancellationToken);
            }
            catch (Exception)
            {
                throw new Exception("An error occurred while creating the user");
            }

            return new ResultModel
            {
                ResultMessage = "User has been created successfully."
            };
        }
    }
}
