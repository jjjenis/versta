namespace Domain.Entities;

public sealed class Order
{
    public int Id { get; set; }

    public string OrderNumber { get; set; } = string.Empty;

    public string SenderCity { get; set; } = string.Empty;

    public string SenderAddress { get; set; } = string.Empty;

    public string RecipientCity { get; set; } = string.Empty;

    public string RecipientAddress { get; set; } = string.Empty;

    public int CargoWeight { get; set; }

    public DateTime PickupDate { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}