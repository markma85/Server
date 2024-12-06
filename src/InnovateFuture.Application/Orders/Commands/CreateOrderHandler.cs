using InnovateFuture.Infrastructure.Interfaces;
using MediatR;
using InnovateFuture.Domain.Entities;

namespace InnovateFuture.Application.Orders.Commands
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IOrderRepository _orderRepository;

        public CreateOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order(request.CustomerName);

            foreach (var item in request.Items)
            {
                order.AddItem(item.ProductName, item.Quantity, item.UnitPrice);
            }

            await _orderRepository.AddAsync(order);
            return order.Id;
        }
    }
}

