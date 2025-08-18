namespace Market.Domain.Entities;

public class ProductCategory : BaseEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}