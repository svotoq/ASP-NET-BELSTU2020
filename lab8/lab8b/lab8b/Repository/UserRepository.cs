using lab8b.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab8b.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _databaseContext;

        public UserRepository(ApplicationContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<List<User>> GetUsers()
        {
            return await _databaseContext.Users.AsNoTracking().ToListAsync();
        }

        public async Task<User> GetUser(int id)
        {
            return await _databaseContext.Users
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddUser(User user)
        {
            await _databaseContext.Users.AddAsync(user);

            await _databaseContext.SaveChangesAsync();
        }

        public async Task<User> UpdateUser(User user)
        {
            _databaseContext.Users.Update(user);

            await _databaseContext.SaveChangesAsync();

            return user;
        }

        public async Task RemoveUser(int id)
        {
            var removableUser = await _databaseContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            if (removableUser != null)
            {
                _databaseContext.Remove(removableUser);
            }

            await _databaseContext.SaveChangesAsync();
        }
    }
}
