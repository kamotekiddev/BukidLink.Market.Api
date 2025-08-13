namespace Market.Application.DTOs.User;

public class UserDto
{
    public Guid Id { get; set; }
    public required string Email { get; set; }
    public required string Name { get; set; }
    public bool IsEmailVerified { get; set; } = false;
}