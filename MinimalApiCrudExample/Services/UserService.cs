using CrudExampleDatabase;
using CrudExampleDatabase.Models;
using Microsoft.EntityFrameworkCore;

namespace MinimalApiCrudExample.Services
{
    public class UserService
    {
        private readonly CrudExampleDbContext _db;
        public UserService(CrudExampleDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<User?>> GetAllUsers() => await _db.Users.ToListAsync();

        public async Task<User?> GetUser(string id) => await _db.Users.FindAsync(id);

        public async Task<User?> AddUser(User user)
        {
            user.Id = Guid.NewGuid().ToString();
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
            return user;
        }

        public async Task<User?> UpdateUser(User user)
        {
            var existingUser = await _db.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
            if (existingUser is null)
            {
                return null;
            }
            existingUser.Name = user.Name;
            existingUser.Age = user.Age;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;
            _db.Users.Update(existingUser);
            await _db.SaveChangesAsync();
            return existingUser;
        }

        public async Task<User?> DeleteUser(string id)
        {
            var existingUser = await _db.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (existingUser is null)
            {
                return null;
            }
            _db.Users.Remove(existingUser);
            await _db.SaveChangesAsync();
            return existingUser;
        }

        public async Task<List<User>?> DeleteAllUsers()
        {
            var existingUsers = await _db.Users.ToListAsync();
            if (existingUsers is null)
            {
                return null;
            }
            _db.Users.RemoveRange(existingUsers);
            await _db.SaveChangesAsync();
            return existingUsers;
        }
    }
}
