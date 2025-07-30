using Market.Domain.Entities;

namespace Market.Application.Interfaces;

public interface IUserRolesRepository
{
    Task<UserRole> AddUserRole(UserRole userRole);
}