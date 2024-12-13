using MediatR;
using InnovateFuture.Application.DTOs;

namespace InnovateFuture.Application.Queries.Orders;

public class GetOrderQuery : IRequest<OrderResponse>
{
    public Guid OrderId { get; set; }
}


