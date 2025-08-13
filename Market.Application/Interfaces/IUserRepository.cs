using Market.Domain.Entities;

namespace Market.Application.Interfaces;

public interface IUserRepository
{
    Task<User> SaveUserAsync(User user);
    Task<User> UpdateUserAsync(User user);
    Task<User?> FindUserByEmailAsync(string email);
    Task<User?> FindUserByIdAsync(Guid userId);
}