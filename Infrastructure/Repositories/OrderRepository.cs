using Application.Abstractions.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repositories;

internal sealed class OrderRepository(AppDbContext context) : IOrderRepository
{
    public async Task<IReadOnlyCollection<Order>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await context.Orders
            .AsNoTracking()
            .OrderByDescending(order => order.CreatedAt)
            .ToListAsync(cancellationToken);
    }

    public async Task<Order?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await context.Orders
            .AsNoTracking()
            .FirstOrDefaultAsync(order => order.Id == id, cancellationToken);
    }

    public async Task AddAsync(Order order, CancellationToken cancellationToken)
    {
        context.Orders.Add(order);
        await context.SaveChangesAsync(cancellationToken);
    }
}