using Microsoft.EntityFrameworkCore;
using InnovateFuture.Domain.Entities;
using InnovateFuture.Infrastructure.Persistence.Interfaces;

namespace InnovateFuture.Infrastructure.Persistence.Repositories;
public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _dbContext;

    public OrderRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Order> GetByIdAsync(Guid id)
    {
        return await _dbContext.Orders
            .Include(o => o.Items)
            .FirstOrDefaultAsync(o => o.Id == id);
    }
    public async Task AddAsync(Order order)
    {
        await _dbContext.Orders.AddAsync(order);
        await _dbContext.SaveChangesAsync();
    }
}