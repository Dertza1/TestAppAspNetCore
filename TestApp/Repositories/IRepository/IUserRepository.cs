using TestApp.Model;

namespace TestApp.Repositories.IRepository;

public interface IUserRepository
{
    public List<User> GetUsers();
    public User? GetUserByID(int userID);
    public List<User> PostUser(User user);
}
