namespace TestApp.Model;

public class Message
{
    public int MessageID { get; set; }
    public int UserID { get; set; }
    public DateTime PublishedDate { get; set; }
    public string Description { get; set; }
    public User User { get; set; }

    public Message(int messageID, int userID, DateTime publishedDate, string description, User user)
    {
        MessageID = messageID;
        UserID = userID;
        PublishedDate = publishedDate;
        Description = description;
        User = user;
    }
}
