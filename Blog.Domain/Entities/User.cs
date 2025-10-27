namespace Blog.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public String  FirstName { get; set; }
    public String LastName { get; set; }
    public String Email { get; set; }
    public String Password { get; set; }
    public DateTime AccountCreationDate { get; set; }
    public String PhoneNumber { get; set; }
    public String ProfileImage { get; set; }
}