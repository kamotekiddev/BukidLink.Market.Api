using Market.Application.Interfaces;
using Market.Domain.Entities;
using Market.Infrastructure.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

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

    public async Task<RefreshToken> FindTokenAsync(string token)
    {
        var refreshToken = await _dbContext.RefreshTokens
            .Include(rt => rt.User)
            .FirstOrDefaultAsync(rt => string.Equals(rt.Token, token));

        if (refreshToken is null) throw new BadHttpRequestException("Token does not exist");

        return refreshToken;
    }

    public async Task<RefreshToken> UpdateTokenAsync(RefreshToken token)
    {
        _dbContext.RefreshTokens.Update(token);
        await _dbContext.SaveChangesAsync();
        return token;
    }
}