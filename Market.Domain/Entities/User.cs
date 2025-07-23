
namespace Market.Domain.Entities;

public class User
{
	public Guid Id { get; set; }
	public required string Email { get; set; }
	public required string Name { get; set; }

	public List<UserRole>? UserRoles { get; set; }
}
