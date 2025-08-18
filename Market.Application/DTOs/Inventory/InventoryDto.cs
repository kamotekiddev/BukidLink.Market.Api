using Market.Application.DTOs.ProductVariant;
using Market.Domain.Enums;

namespace Market.Application.DTOs.Inventory;

public class InventoryDto
{
    public Guid Id { get; set; }
    public int Quantity { get; set; }
    public int BatchNumber { get; set; }
    public string Sku { get; set; }
    public InventoryStatus Status { get; set; } = InventoryStatus.Pending;

    public DateTime DateReceived { get; set; }
    public DateTime? DateExpired { get; set; }

    public Guid ProduceVariantId { get; set; }
    public ProductVariantDto? ProduceVariant { get; set; }
}