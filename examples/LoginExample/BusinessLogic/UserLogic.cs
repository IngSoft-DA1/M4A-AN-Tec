using Domain;
using Repository;

namespace BusinessLogic;

public class UserLogic
{
    private readonly IRepository<User> _repository;

    public UserLogic(IRepository<User> userRepository)
    {
        _repository = userRepository;
    }

    public User Login(User anyUser)
    {
        User? user = _repository.Find(userOnRepository => userOnRepository.Name == anyUser.Name && 
                                                          userOnRepository.Password == anyUser.Password);
        if(user == null)
        {
            throw new Exception("No existe un usuario con ese nombre y/o contraseña.");
        }
        return user;
    }
    
    public User AddUser(User user)
    {
        return _repository.Add(user);
    }

    public IList<User> GetAll()
    {
        return _repository.FindAll();
    }

    public User? FindById(int id)
    {
        return _repository.Find(x => x.Id == id);
    }

    public User? Update(User updatedUser)
    {
        return _repository.Update(updatedUser);
    }

    public void Delete(int id)
    {
        _repository.Delete(id);
    }
    

}