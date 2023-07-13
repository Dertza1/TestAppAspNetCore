using TestApp.Model;
using TestApp.Repositories.IRepository;

namespace TestApp.Repositories.Repository;

public class UserRepository : IUserRepository
{
    public User? GetUserByID(int userID)
    {
        return Data.Users.FirstOrDefault(user => user.UserID == userID);
    }
    public List<User> GetUsers()
    {
        return Data.Users;
    }
    public List<User> PostUser(User user)
    {
        Data.Users.Add(user);

        return GetUsers();
    }
}
