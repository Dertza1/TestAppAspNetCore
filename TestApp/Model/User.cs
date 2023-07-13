namespace TestApp.Model;

public class User
{
    public int UserID { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }

    public List<Message> Messages = new List<Message>();


    public User(int userID, string lastName, string firstName)
    {
        UserID = userID;
        LastName = lastName;
        FirstName = firstName;
    }
}
