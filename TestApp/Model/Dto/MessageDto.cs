namespace TestApp.Model.Dto
{
    public class MessageDto
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Description { get; set; }

        public MessageDto(string lastName, string firstName, DateTime publishedDate, string description)
        {
            LastName = lastName;
            FirstName = firstName;
            PublishedDate = publishedDate;
            Description = description;
        }
    }
}
