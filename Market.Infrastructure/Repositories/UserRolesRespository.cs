using Market.Application.Interfaces;
using Market.Domain.Entities;
using Market.Infrastructure.Context;

namespace Market.Infrastructure.Repositories;

public class UserRolesRespository : IUserRolesRepository
{
    private readonly AppDbContext _dbContext;

    public UserRolesRespository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<UserRole> AddUserRole(UserRole userRole)
    {
        _dbContext.UserRoles.Add(userRole);
        await _dbContext.SaveChangesAsync();
        return userRole;
    }
}