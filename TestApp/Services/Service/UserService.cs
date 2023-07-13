using TestApp.Model;
using TestApp.Model.Dto;
using TestApp.Model.Dto.Post;
using TestApp.Repositories.IRepository;
using TestApp.Services.IService;

namespace TestApp.Services.Service
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserDto? GetUserByID(int userID)
        {
            var user = _userRepository.GetUserByID(userID);

            if (user is null)
            {
                return null;
            }

            return new UserDto(user.LastName, user.FirstName);
        }

        public List<UserDto> GetUsers()
        {
            var users = _userRepository.GetUsers();

            if (users.Count == 0)
            {
                return null;
            }

            var usersDto = new List<UserDto>();

            foreach (var user in users)
            {
                usersDto.Add(new UserDto(user.LastName, user.FirstName));
            }

            return usersDto;
        }

        public List<UserDto> PostUser(PostUserDto user)
        {
            var newUser = new User(_userRepository.GetUsers().Max(id => id.UserID) + 1, user.LastName, user.FirstName);

            var users = _userRepository.PostUser(newUser);

            return GetUsers();
        }
    }
}
