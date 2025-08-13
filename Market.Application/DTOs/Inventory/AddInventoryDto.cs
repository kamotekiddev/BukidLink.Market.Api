namespace Market.Application.DTOs.Inventory;

public class AddInventoryDto
{
    public int Quantity { get; set; }
    public string Sku { get; set; }
    public Guid ProduceId { get; set; }

    public DateTime DateReceived { get; set; }
    public DateTime? DateExpired { get; set; }
}