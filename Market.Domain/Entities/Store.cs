namespace Market.Domain.Entities;

public class Store : BaseEntity
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? CoverPhotoUrl { get; set; }
    public string? ProfilePhotoUrl { get; set; }

    public Guid OwnerId { get; set; }
    public User? Owner { get; set; }
    public List<Produce>? Produce { get; set; }
}