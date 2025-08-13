namespace Market.Domain.Enums;

public enum InventoryStatus
{
    Available, // Available for sale
    OutOfStock, // Not available to sell
    Reserved, // Held for an order, not yet shipped
    Damaged, // Unsellable stock
    Expired, // Past expiry date, removed from sale
    Pending, // Awaiting stock arrival or processing
}