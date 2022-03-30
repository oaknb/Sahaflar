using Sahaflar.Entities;
using Sahaflar.Repositories.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace Sahaflar.Repositories.Concrete
{
    public class UserRepository : IUserRepository
    {
        private Sahafs context;
        public UserRepository(Sahafs context)
        {
            this.context = context;
        }
        public bool AddUser(User user)
        {
            context.Users.Add(user);

            return context.SaveChanges() > 0;
        }

        public User GetUserById(int id)
        {
           User user = context.Users.Where(x => x.UserId == id).SingleOrDefault();

            return user;
        }

        public List<User> GetUsers()
        {
            return context.Users.ToList() ;
        }
    }
}
