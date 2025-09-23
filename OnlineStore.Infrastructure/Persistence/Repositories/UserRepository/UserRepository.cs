using OnlineStore.Domain.Entities.User;
using OnlineStore.Domain.Repositories.UserRepository;
using OnlineStore.Infrastructure.Persistence.Context;
using OnlineStore.Infrastructure.Persistence.Repositories.Base;

namespace OnlineStore.Infrastructure.Persistence.Repositories.UserRepository
{
    public class UserRepository : GenericRepository<Users, ProductDbContext>, IUserRepository
    {
        public UserRepository(ProductDbContext context)
            : base(context)
        {

        }
    }
}
