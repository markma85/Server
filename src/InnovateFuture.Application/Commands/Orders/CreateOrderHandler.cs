using AutoMapper;
using MediatR;
using InnovateFuture.Domain.Entities;
using InnovateFuture.Infrastructure.Persistence.Interfaces;

namespace InnovateFuture.Application.Commands.Orders;
public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Guid>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;
    public CreateOrderHandler(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        // Use AutoMapper to map the request to the Order entity
        var order = _mapper.Map<Order>(request);

        // Add the order to the repository
        await _orderRepository.AddAsync(order);

        // Return the newly created order's ID
        return order.Id;
    }
}

