using Domain;

namespace Repository
{
    public class UserRepository : IRepository<User>
    {
        private readonly List<User> _users;

        public UserRepository()
        {
            _users = new List<User>()
            {
                new User()
                {
                    Id = 1,
                    Name = "adminadmin",
                    Password = "adminadmin"
                }
            };
        }

        public User Add(User user)
        {
            _users.Add(user);
            return user;
        }

        public User? Find(Func<User, bool> filter)
        {
            return _users.FirstOrDefault(filter);
        }

        public IList<User> FindAll()
        {
            return _users;
        }

        public User? Update(User updatedUser)
        {
            User? existingUser = _users.FirstOrDefault(u => u.Id == updatedUser.Id);
            if (existingUser != null)
            {
                existingUser.Name = updatedUser.Name;
                existingUser.Password = updatedUser.Password;
                return existingUser;
            }
            return null;
        }

        public void Delete(int id)
        {
            User? user = _users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _users.Remove(user);
            }
        }
    }
}