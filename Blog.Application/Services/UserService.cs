using System.ComponentModel.DataAnnotations;
using Blog.Application.Interfaces;

namespace Blog.Application.Services;

public sealed class UserService : IUserService
{
    private readonly IUserRepository _userService;

    public UserService(IUserRepository userService)
    {
        _userService = userService;
    }

    public async Task<UserEntityDto> CreateUserAsync(string firstName, string lastName, DateTime accountCreationDate,
        EmailAddressAttribute email,
        PhoneAttribute phone, CancellationToken ct = default)
    {
        var user = new UserEntity
        {
            FirstName = firstName,
            LastName = lastName,
            AccountCreationDate = accountCreationDate,
            Email = email,
            Phone = phone
        };
        await _userService.Add(user, ct);
        return user;

    }

    //public async Task<UserEntityDto> UpdateUserAsync(CancellationToken ct = default)
    //    {
    //        
    //    }

    public async Task<UserEntityDto> DeleteUserAsync(CancellationToken ct = default) 
    {
        
    }

    public Task<UserEntityDto> GetUserById(int userId, CancellationToken ct = default) =>
        _userService.GetByIdAsync(userId, ct);

    public async Task<List<UserEntityDto>> GetAllUsersAsync(CancellationToken ct = default)
    {
        
    }

}