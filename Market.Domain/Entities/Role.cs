namespace Market.Domain.Entities;

public class Role
{
    public Guid Id { get; set; }
    public required string Name { get; set; }

    public List<UserRole> UserRoles { get; set; }
}