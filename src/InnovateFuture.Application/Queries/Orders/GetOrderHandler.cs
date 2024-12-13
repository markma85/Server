using MediatR;
using AutoMapper;
using InnovateFuture.Application.DTOs;
using InnovateFuture.Infrastructure.Persistence.Interfaces;

namespace InnovateFuture.Application.Queries.Orders;
public class GetOrderHandler : IRequestHandler<GetOrderQuery, OrderResponse>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;
    public GetOrderHandler(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<OrderResponse> Handle(GetOrderQuery request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(request.OrderId);

        // Use AutoMapper to map Order to OrderDto
        return _mapper.Map<OrderResponse>(order);
    }
}

