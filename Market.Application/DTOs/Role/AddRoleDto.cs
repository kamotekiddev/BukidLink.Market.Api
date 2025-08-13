using System.ComponentModel.DataAnnotations;
using Market.Application.Constants;

namespace Market.Application.DTOs.Role;

public class AddRoleDto
{
    [Required]
    [AllowedRoles(RoleConstants.User, RoleConstants.Admin, RoleConstants.Farmer)]
    public required string Name { get; set; }
}