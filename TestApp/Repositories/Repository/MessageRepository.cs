using TestApp.Model;
using TestApp.Repositories.IRepository;

namespace TestApp.Repositories.Repository;

public class MessageRepository : IMessageRepository
{
    private IUserRepository _userRepository;
    public MessageRepository(IUserRepository userRepository)
    {
        _userRepository = userRepository;        
    }
    public List<Message>? GetLastMessagesForUsers(int countUsers)
    {
        var users = _userRepository.GetUsers()
            .Where(message => message.Messages.Any())
            .OrderByDescending(user => user.Messages.Max(message => message.PublishedDate))
            .Take(countUsers).ToList();

        if (users.Count == 0)
        {
            return null;
        }

        var lastMessages = new List<Message>();

        foreach (var user in users)
        {
            lastMessages.Add(user.Messages.OrderByDescending(m => m.PublishedDate).First());
        }

        return lastMessages;
    }
    public List<Message>? GetMessagesForUser(int userID)
    {
        var user = _userRepository.GetUserByID(userID);

        if (user is null)
        {
            return null;
        }

        return user.Messages.OrderByDescending(m => m.PublishedDate).ToList();
    }
    public Message? PostMessage(Message postMessage)
    {
        var user = _userRepository.GetUserByID(postMessage.UserID);

        user.Messages.Add(postMessage);

        return postMessage;
    }
}
