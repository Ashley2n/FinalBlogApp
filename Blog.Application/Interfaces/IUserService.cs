using System.ComponentModel.DataAnnotations;

namespace Blog.Application.Interfaces;

public class IUserService
{
    Task<UserEntityDTO> CreateUserAsync(string firstName, string lastName, DateTime accountCreationDate, EmailAddressAttribute email, PhoneAttribute phone, CancellationToken ct = default);

    Task<UserEntityDTO> UpdateUserAsync(CancellationToken ct = default);
    
    Task<UserEntityDTO> DeleteUserAsync(CancellationToken ct = default);
    
    Task<UserEntityDTO> GetUserByIdAsync(int userId, CancellationToken ct = default);
    
    Task<List<UserEntityDTO>> GetAllUsersAsync(CancellationToken ct = default);
}