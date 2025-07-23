using Market.Application.Interfaces;
using Market.Domain.Entities;
using Market.Infrastructure.Context;

namespace Market.Infrastructure.Repositories;

public class RefreshTokenRepository : IRefreshTokenRepository
{
    private readonly AppDbContext _dbContext;

    public RefreshTokenRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<RefreshToken> SaveTokenAsync(RefreshToken token)
    {
        _dbContext.RefreshTokens.Add(token);
        await _dbContext.SaveChangesAsync();
        return token;
    }
}