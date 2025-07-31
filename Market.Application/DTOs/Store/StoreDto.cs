namespace Market.Application.DTOs.Store;

public class StoreDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? CoverPhotoUrl { get; set; }
    public string? ProfilePhotoUrl { get; set; }
    public Guid OwnerId { get; set; }
}