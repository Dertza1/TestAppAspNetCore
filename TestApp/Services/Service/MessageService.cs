using TestApp.Model;
using TestApp.Model.Dto;
using TestApp.Model.Dto.Post;
using TestApp.Repositories.IRepository;
using TestApp.Services.IService;

namespace TestApp.Services.Service;

public class MessageService : IMessageService
{
    private IMessageRepository _messageRepository;
    private IUserRepository _userRepository;
    public MessageService(IMessageRepository messageRepository, IUserRepository userRepository) 
    {
        _messageRepository = messageRepository;
        _userRepository = userRepository;
    }
    public List<MessageDto>? GetLastMessagesForUsers(int countUsers)
    {
        var lastMessagesForUsers = _messageRepository.GetLastMessagesForUsers(countUsers);

        if (lastMessagesForUsers is null)
        {
            return null;
        }

        var lastMessagesDtoForUsers = new List<MessageDto>();

        foreach (var message in lastMessagesForUsers)
        {
            lastMessagesDtoForUsers.Add(new MessageDto(message.User.LastName, message.User.FirstName, message.PublishedDate, message.Description));
        }

        return lastMessagesDtoForUsers;
    }
    public List<MessageDto>? GetMessagesForUser(int userID)
    {
        var messageForUser = _messageRepository.GetMessagesForUser(userID);

        if (messageForUser == null)
        {
            return null;    
        }

        var messagesDtoForUser = new List<MessageDto>();

        foreach (var message in messageForUser)
        {
            messagesDtoForUser.Add(new MessageDto(message.User.LastName, message.User.FirstName, message.PublishedDate, message.Description));
        }

        return messagesDtoForUser;
    }
    public MessageDto? PostMessage(int userID, PostMessageDto postMessage)
    {
        var messagesForUser = _messageRepository.GetMessagesForUser(userID);

        if (messagesForUser is null)
        {
            return null;
        }

        var user = _userRepository.GetUserByID(userID);

        int lastMessageID = messagesForUser.Count > 0 ? messagesForUser.Max(id => id.MessageID) + 1 : 1;

        var newMessage = _messageRepository.PostMessage(new Message(lastMessageID, userID, postMessage.PublishedDate, postMessage.Description, user));//need convert

        if (newMessage is null)
        {
            return null;
        }

        return new MessageDto(newMessage.User.LastName, newMessage.User.FirstName, newMessage.PublishedDate, newMessage.Description);
    }
}
