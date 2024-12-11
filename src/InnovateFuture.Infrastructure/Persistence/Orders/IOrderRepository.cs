using InnovateFuture.Domain.Entities;

namespace InnovateFuture.Infrastructure.Persistence.Orders
{
    public interface IOrderRepository
    {
        Task<Order> GetByIdAsync(Guid id);
        Task AddAsync(Order order);
    }
}