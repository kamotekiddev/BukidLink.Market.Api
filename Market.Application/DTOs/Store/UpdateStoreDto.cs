using System.ComponentModel.DataAnnotations;

namespace Market.Application.DTOs.Store;

public class UpdateStoreDto
{
    [Required] public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string CoverPhotoUrl { get; set; } = string.Empty;
    public string ProfilePhotoUrl { get; set; } = string.Empty;
}