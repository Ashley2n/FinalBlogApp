namespace Blog.Application.DTO.Users;

public class UserDto
{
    public UserDto(int id, string firstName, string lastName, string email, DateTime accountCreationDate, string phoneNumber, string profilePictureImage)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        AccountCreationDate = accountCreationDate;
        this.phoneNumber = phoneNumber;
        this.profilePictureImage = profilePictureImage;
    }

    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime AccountCreationDate { get; set; }
    public string phoneNumber{get;set;}
    public string profilePictureImage { get; set; }
}