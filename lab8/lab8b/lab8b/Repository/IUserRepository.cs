using lab8b.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab8b.Repository
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();

        Task<User> GetUser(int id);

        Task AddUser(User user);

        Task<User> UpdateUser(User user);

        Task RemoveUser(int id);
    }
}
