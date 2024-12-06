using MediatR;
using InnovateFuture.Application.DTOs;

namespace InnovateFuture.Application.Orders.Query.GetOrder
{
    public class GetOrderQuery : IRequest<OrderDto>
    {
        public Guid OrderId { get; set; }
    }
}

