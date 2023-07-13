using TestApp.Model;

namespace TestApp.Repositories.IRepository;

public interface IMessageRepository
{
    public List<Message>? GetMessagesForUser(int userID);
    public List<Message>? GetLastMessagesForUsers(int countUsers);
    public Message? PostMessage(Message postMessage);
}
