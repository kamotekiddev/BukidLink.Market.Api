using Market.Domain.Entities;

namespace Market.Application.Interfaces;

public interface IUserRepository
{
    Task<User> SaveUserAsync(User user);
    Task<User?> FindUserByEmail(string email);
}