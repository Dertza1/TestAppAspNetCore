using Microsoft.AspNetCore.Mvc;
using TestApp.Model.Dto;
using TestApp.Model.Dto.Post;
using TestApp.Services.IService;

namespace TestApp.Controllers;

[Route("[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("users")]
    public ActionResult<List<UserDto>> GetUsers()
    {
        return Ok(_userService.GetUsers());
    }

    [HttpGet("user/{userID}")]
    public ActionResult<UserDto> GetUserByID(int userID)
    {
        var user = _userService.GetUserByID(userID);

        if (user is null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpPost("postUser")]
    public ActionResult<List<UserDto>> PostUser([FromBody] PostUserDto user)
    {
        return _userService.PostUser(user);
    }
}
