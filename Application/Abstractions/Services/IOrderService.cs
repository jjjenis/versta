using Domain.Entities;

namespace Application.Abstractions.Services;

public interface IOrderService
{
    Task<IReadOnlyCollection<Order>> GetAllAsync(CancellationToken cancellationToken);

    Task<Order?> GetByIdAsync(int id, CancellationToken cancellationToken);

    Task<Order> CreateAsync(CreateOrderRequest request, CancellationToken cancellationToken);
}
