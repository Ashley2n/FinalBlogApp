using System.ComponentModel.DataAnnotations;

namespace Blog.Application.Interfaces;

public interface IUserService
{
    Task<User> CreateUserAsync(CreateUserDto dto, CancellationToken ct = default);

    Task<User> UpdateUserAsync(UpdateUserDTO dto, CancellationToken ct = default);
    
    Task<bool> DeleteUserAsync(UserDro dto, CancellationToken ct = default);
    
    Task<User> GetUserById(UserDro dto, CancellationToken ct = default);
    
    Task<List<User>> GetAllUsers(CancellationToken ct = default);
}