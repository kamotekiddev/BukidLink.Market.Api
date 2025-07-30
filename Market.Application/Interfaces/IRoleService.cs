using Market.Domain.Entities;

namespace Market.Application.Interfaces;

public interface IRoleService
{
    Task<List<Role>> GetAllRolesAsync();
    Task<Role> AddRoleAsync(string roleName);
    Task<Role> UpdateRoleAsync(Guid roleId, string roleName);
}