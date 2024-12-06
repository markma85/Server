using InnovateFuture.Infrastructure.Interfaces;
using InnovateFuture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InnovateFuture.Infrastructure.Persistence
{
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
                .Include(o => o.Items) // Include related OrderItems
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task AddAsync(Order order)
        {
            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();
        }

        
    }
}