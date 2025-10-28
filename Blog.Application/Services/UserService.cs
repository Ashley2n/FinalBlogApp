using System.ComponentModel.DataAnnotations;
using Blog.Application.Interfaces;
using Blog.Domain.Entities;
using Blog.Infrastructure.Repositories;

namespace Blog.Application.Services;

public sealed class UserService : IUserService
{
    private readonly UserRepository _userService;

    public UserService(UserRepository userService)
    {
        _userService = userService;
    }

    public async Task<User> CreateUserAsync(CreateUserDto dto, CancellationToken ct = default)
    {
        var user = new User
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber,
            ProfileImage = dto.ProfileImage,
        };
        await _userService.AddAsync(user, ct);
        return user;

    }

    public async Task<User> UpdateUserAsync(UpdateUserDTO dto, CancellationToken ct = default)
        {
            var user = await _userService.GetById(dto.Id, ct);

            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.Email = dto.Email;
            user.PhoneNumber = dto.PhoneNumber;
            user.ProfileImage = dto.ProfileImage;
            
            await _userService.UpdateAsync(user, ct);
            return user;
        }

    public async Task<bool> DeleteUserAsync(UserDro dto, CancellationToken ct = default)
    {
        var entity = await _userService.GetById(dto.Id, ct);
        if (entity == null) return false;
        await _userService.DeleteAsync(entity, ct);
        return true;
    }

    public async Task<User> GetUserById(UserDro dto, CancellationToken ct = default) =>
        await _userService.GetById(dto, ct);

    public async Task<List<User>> GetAllUsers(CancellationToken ct = default) =>
        await _userService.GetAll(ct);
}