using Market.Domain.Entities;

namespace Market.Application.Interfaces;

public interface IRoleRepository
{
    Task<Role> AddRoleAsync(Role role);
    Task<List<Role>> GetAllRolesAsync();
    Task<Role> UpdateRoleAsync(Role role);
    Task<Role?> GetRoleByIdAsync(Guid roleId);
}