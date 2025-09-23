using OnlineStore.Domain.Entities.Base;
using OnlineStore.Domain.Entities.OrderAggregate;
using OnlineStore.Domain.Entities.OrderItemAggregate;

namespace OnlineStore.Domain.Entities.User
{
    public enum AppRole { User = 0, Admin = 1 }
    public class Users : BaseEntity<int>
    {
        public Users(string firstName, string lastName, string userName,
                     string password, AppRole role)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Password = password;
            Role = role;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public AppRole Role { get; private set; }

        public virtual ICollection<Order> Orders { get; protected set; } = new List<Order>();

        public static Users RegisterUser(string firstName,
                                         string lastName,
                                         string userName,
                                         string password,
                                         AppRole role) => new(firstName,
                                                                 lastName,
                                                                 userName,
                                                                 password,
                                                                 role);
       
    }
}
