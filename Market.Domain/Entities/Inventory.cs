using System.ComponentModel.DataAnnotations.Schema;

namespace Market.Domain.Entities;

public class Inventory : BaseEntity
{
    public Guid Id { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public int BatchNumber { get; set; }

    public int Quantity { get; set; }
    public string Sku { get; set; }
    public DateTime DateReceived { get; set; }
    public DateTime? DateExpired { get; set; }

    public Guid ProduceId { get; set; }
    public Produce? Produce { get; set; }
}