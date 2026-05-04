namespace Application.Abstractions.Services;

public sealed record CreateOrderRequest(
    string SenderCity,
    string SenderAddress,
    string RecipientCity,
    string RecipientAddress,
    int CargoWeight,
    DateTime PickupDate);
