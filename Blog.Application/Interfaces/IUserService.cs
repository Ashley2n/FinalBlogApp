using System.ComponentModel.DataAnnotations;
using Blog.Domain.Entities;

namespace Blog.Application.Interfaces;
using Blog.Application.DTO.Users;

public interface IUserService
{
    Task<User> CreateUserAsync(CreateUserDto dto, CancellationToken ct = default);

    Task<User> UpdateUserAsync(UpdateUserDto dto, CancellationToken ct = default);
    
    Task<bool> DeleteUserAsync(UserDto dto, CancellationToken ct = default);
    
    Task<User> GetUserById(int id, CancellationToken ct = default);
    
    Task<List<User>> GetAllUsers(CancellationToken ct = default);
}