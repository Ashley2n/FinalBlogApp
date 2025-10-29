namespace Blog.Application.DTO.Users;

public class CreateUserDto
{
    public CreateUserDto(string firstName, string lastName, string email, string password, string phoneNumber, string profileImage)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        this.phoneNumber = phoneNumber;
        this.profileImage = profileImage;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string phoneNumber { get; set; }
    public string profileImage { get; set; }
}