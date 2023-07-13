using TestApp.Model.Dto;
using TestApp.Model.Dto.Post;

namespace TestApp.Services.IService;

public interface IUserService
{
    public List<UserDto> GetUsers();
    public UserDto? GetUserByID(int userID);
    public List<UserDto> PostUser(PostUserDto user);
}
