using Market.Application.Interfaces;
using Market.Domain.Entities;
using Market.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Market.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _dbContext;

    public UserRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User> SaveUserAsync(User user)
    {
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();

        return user;
    }

    public async Task<User> UpdateUserAsync(User user)
    {
        _dbContext.Users.Update(user);
        await _dbContext.SaveChangesAsync();

        return user;
    }

    public async Task<User?> FindUserByEmailAsync(string email)
    {
        var user = await _dbContext.Users
            .FirstOrDefaultAsync(user => string.Equals(user.Email, email));

        return user;
    }

    public async Task<User?> FindUserByIdAsync(Guid userId)
    {
        return await _dbContext.Users.FindAsync(userId);
    }
}