using System.ComponentModel.DataAnnotations;
using Market.Application.Constants;

namespace Market.Application.DTOs;

public class RegisterDto
{
    [Required] [EmailAddress] public required string Email { get; set; }

    [Required]
    [MinLength(5)]
    [MaxLength(20)]
    public required string Name { get; set; }

    [Required]
    [AllowedRoles(RoleConstants.Farmer, RoleConstants.User)]
    public required string Role { get; set; } = RoleConstants.User;

    [Required]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$",
        ErrorMessage =
            "Password must be at least 8 characters and contain uppercase, lowercase, number, and special character.")]
    public required string Password { get; set; }
}