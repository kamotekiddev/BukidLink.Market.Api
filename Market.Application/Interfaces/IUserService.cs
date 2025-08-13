using Market.Application.DTOs.User;

namespace Market.Application.Interfaces;

public interface IUserService
{
    Task<UserDto> CreateUserAsync(AddUserDto dto);
    Task<UserDto> UpdateUserAsync(Guid userId, UpdateUserDto dto);
    Task<UserDto> AssignRoleToUserAsync(Guid userId, Guid roleId);
    Task<UserDto> GetUserByEmailAsync(string email);
    Task<UserDto> GetCurrentUser();
}