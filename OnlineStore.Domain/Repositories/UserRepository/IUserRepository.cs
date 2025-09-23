using OnlineStore.Domain.Entities.User;
using OnlineStore.Domain.Repositories.Base;

namespace OnlineStore.Domain.Repositories.UserRepository
{
    public interface IUserRepository : IGenericRepository<Users>
    {
    }
}
