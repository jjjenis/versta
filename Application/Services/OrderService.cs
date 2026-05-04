using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Domain.Entities;

namespace Application.Services;

internal sealed class OrderService(IOrderRepository repository) : IOrderService
{
    public Task<IReadOnlyCollection<Order>> GetAllAsync(CancellationToken cancellationToken)
    {
        return repository.GetAllAsync(cancellationToken);
    }

    public Task<Order?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return repository.GetByIdAsync(id, cancellationToken);
    }

    public async Task<Order> CreateAsync(CreateOrderRequest request, CancellationToken cancellationToken)
    {
        var order = new Order
        {
            OrderNumber = GenerateOrderNumber(),
            SenderCity = request.SenderCity,
            SenderAddress = request.SenderAddress,
            RecipientCity = request.RecipientCity,
            RecipientAddress = request.RecipientAddress,
            CargoWeight = request.CargoWeight,
            PickupDate = request.PickupDate,
            CreatedAt = DateTime.UtcNow,
        };

        await repository.AddAsync(order, cancellationToken);

        return order;
    }

    private static string GenerateOrderNumber()
    {
        return $"ORD-{DateTime.UtcNow:yyyyMMddHHmmss}-{Random.Shared.Next(1000, 9999)}";
    }
}
