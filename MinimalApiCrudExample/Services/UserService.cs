using MinimalApiCrudExample.Models;

namespace MinimalApiCrudExample.Services
{
    public class UserService
    {
        private List<User> _users { get; set; } = new();

        public UserService()
        {
            _users.Add(new User
            {
                Id = "52292945-abf0-45ae-a39a-af0f7746b05b",
                Name = "Hector Salamanca",
            });
        }

        public IEnumerable<User> GetAllUsers() => _users;

        public User? GetUser(string id)
        {
            return _users.FirstOrDefault(user => user.Id == id);
        }

        public User AddUser(User user)
        {
            user.Id = Guid.NewGuid().ToString();
            _users.Add(user);
            return user;
        }

        public User? UpdateUser(User user)
        {
            var existingUser = _users.FirstOrDefault(u => u.Id == user.Id);
            if (existingUser is not null)
            {
                existingUser.Name = user.Name;
            }
            return existingUser;
        }

        public User? DeleteUser(string id)
        {
            var existingUser = _users.FirstOrDefault(u => u.Id == id);
            if (existingUser is not null)
            {
                _users.Remove(existingUser);
            }
            return existingUser;
        }
    }
}
