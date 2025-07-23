using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Market.Domain.Entities;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public required string Email { get; set; }
    public required string Name { get; set; }
    public required string Password { get; set; }
    public bool IsEmailVerified { get; set; } = false;

    public List<UserRole>? UserRoles { get; set; }
}