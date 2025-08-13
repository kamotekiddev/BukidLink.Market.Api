using Market.Application.DTOs.Produce;

namespace Market.Application.DTOs.Inventory;

public class InventoryDto
{
    public Guid Id { get; set; }
    public int Quantity { get; set; }
    public int BatchNumber { get; set; }
    public string Sku { get; set; }
    public DateTime DateReceived { get; set; }
    public DateTime? DateExpired { get; set; }

    public Guid ProduceId { get; set; }
    public ProduceDto? Produce { get; set; }
}