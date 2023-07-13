namespace TestApp.Model.Dto;

public class UserDto
{
    public string LastName { get; set; }
    public string FirstName { get; set; }

    public UserDto(string lastName, string firstName)
    {
        LastName = lastName;
        FirstName = firstName;
    }
}
