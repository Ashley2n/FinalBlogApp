using System.ComponentModel.DataAnnotations;
using Blog.Application.DTO.Users;
using Blog.Application.Interfaces;
using Blog.Domain.Entities;
using Blog.Domain.Repositories;
using Blog.Infrastructure.Repositories;
using Microsoft.Identity.Client;


namespace Blog.Application.Services;

public sealed class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> CreateUserAsync(CreateUserDto dto, CancellationToken ct = default)
    {
        var user = new User
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            PhoneNumber = dto.phoneNumber,
            ProfileImage = dto.profileImage,
        };
        await _userRepository.AddAsync(user, ct);
        return user;

    }

    public async Task<User> UpdateUserAsync(UpdateUserDto dto, CancellationToken ct = default)
        {
            var user = await _userRepository.GetById(dto.Id, ct);

            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.Email = dto.Email;
            user.PhoneNumber = dto.PhoneNumber;
            user.ProfileImage = dto.ProfileImage;
            
            await _userRepository.UpdateAsync(user, ct);
            return user;
        }

    public async Task<bool> DeleteUserAsync(UserDto dto, CancellationToken ct = default)
    {
        var entity = await _userRepository.GetById(dto.Id, ct);
        if (entity == null) return false;
        await _userRepository.DeleteAsync(entity, ct);
        return true;
    }

    public async Task<User> GetUserById(int id, CancellationToken ct = default) =>
        await _userRepository.GetById(id, ct);

    public async Task<List<User>> GetAllUsers(CancellationToken ct = default) =>
        await _userRepository.GetAll(ct);
}