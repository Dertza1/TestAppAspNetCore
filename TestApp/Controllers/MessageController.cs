using Microsoft.AspNetCore.Mvc;
using TestApp.Model.Dto;
using TestApp.Model.Dto.Post;
using TestApp.Services.IService;

namespace TestApp.Controllers;

[Route("[controller]")]
[ApiController]
public class MessageController : ControllerBase
{
    private IMessageService _messageService;

    public MessageController(IMessageService messageService)
    {
        _messageService = messageService;
    }

    [HttpGet("messageForUser/{userID}")]
    public ActionResult<List<MessageDto>> GetMessageForUser(int userID)
    {
        var messages = _messageService.GetMessagesForUser(userID);

        if (messages == null)
        {
            return NotFound();
        }

        return Ok(messages);
    }

    [HttpGet("getLastMessages/{countUsers}")]
    public ActionResult<List<MessageDto>> PostMessage(int countUsers)
    {
        var lastMessages = _messageService.GetLastMessagesForUsers(countUsers);

        if (lastMessages is null)
        {
            return BadRequest();
        }

        return Ok(lastMessages);
    }

    [HttpPost("postMessage/{userID}")]
    public ActionResult<MessageDto> PostMessage(int userID, [FromBody] PostMessageDto message)
    {
        var newMessage = _messageService.PostMessage(userID, message);

        if (newMessage is null)
        {
            return BadRequest();
        }

        return Ok(newMessage);
    }

   
}
