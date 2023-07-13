using TestApp.Model.Dto.Post;
using TestApp.Model;
using TestApp.Model.Dto;

namespace TestApp.Services.IService;

public interface IMessageService
{
    public List<MessageDto>? GetMessagesForUser(int userID);
    public List<MessageDto>? GetLastMessagesForUsers(int countUsers);
    public MessageDto? PostMessage(int userID, PostMessageDto postMessage);
}
