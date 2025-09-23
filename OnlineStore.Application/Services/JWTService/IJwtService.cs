using OnlineStore.Domain.Entities.User;

namespace OnlineStore.Application.Services.JWTService
{
    public interface IJwtService
    {
        string GenerateUserToken(string userName, int id, AppRole role);
    }
}
