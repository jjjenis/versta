using Domain.Entities;

namespace Application.Abstractions.Repositories;

public interface IOrderRepository
{
    Task<IReadOnlyCollection<Order>> GetAllAsync(CancellationToken cancellationToken);

    Task<Order?> GetByIdAsync(int id, CancellationToken cancellationToken);

    Task AddAsync(Order order, CancellationToken cancellationToken);
}