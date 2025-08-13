using System.ComponentModel.DataAnnotations.Schema;
using Market.Domain.Enums;

namespace Market.Domain.Entities;

public class Inventory : BaseEntity
{
    public Guid Id { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public int BatchNumber { get; set; }

    public int Quantity { get; set; }
    public string Sku { get; set; } = string.Empty;
    public DateTime DateReceived { get; set; }
    public DateTime? DateExpired { get; set; }
    public InventoryStatus Status { get; set; } = InventoryStatus.Pending;

    public Guid ProduceId { get; set; }
    public Produce? Produce { get; set; }
}