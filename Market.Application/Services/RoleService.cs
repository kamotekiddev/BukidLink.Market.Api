using Market.Application.Interfaces;
using Market.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Market.Application.Services;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;

    public RoleService(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<List<Role>> GetAllRolesAsync()
    {
        return await _roleRepository.GetAllRolesAsync();
    }

    public async Task<Role> AddRoleAsync(string roleName)
    {
        var role = new Role()
        {
            Name = roleName
        };

        await _roleRepository.AddRoleAsync(role);
        return role;
    }

    public async Task<Role> UpdateRoleAsync(Guid roleId, string roleName)
    {
        var role = await _roleRepository.GetRoleByIdAsync(roleId);
        if (role is null) throw new BadHttpRequestException("Role not found.");

        role.Name = roleName;

        await _roleRepository.UpdateRoleAsync(role);
        return role;
    }
}