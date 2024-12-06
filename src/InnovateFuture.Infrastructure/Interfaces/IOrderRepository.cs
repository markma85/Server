using InnovateFuture.Domain.Entities;

namespace InnovateFuture.Infrastructure.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> GetByIdAsync(Guid id);
        Task AddAsync(Order order);
    }
}