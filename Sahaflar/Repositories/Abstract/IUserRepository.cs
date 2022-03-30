using Sahaflar.Entities;
using System.Collections.Generic;

namespace Sahaflar.Repositories.Abstract
{
    public interface IUserRepository
    {
        bool AddUser(User user);
        List<User> GetUsers();

        User GetUserById(int id);
    }
}
