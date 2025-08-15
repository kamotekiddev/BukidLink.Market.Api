using Market.Domain.Enums;

namespace Market.Application.DTOs.Inventory;

public class AddInventoryDto
{
    public int Quantity { get; set; }
    public string Sku { get; set; } = string.Empty;
    public Guid ProduceVariantId { get; set; }
    public InventoryStatus Status { get; set; } = InventoryStatus.Pending;

    public DateTime DateReceived { get; set; }
    public DateTime DateExpired { get; set; }
}