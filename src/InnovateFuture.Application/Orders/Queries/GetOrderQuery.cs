using System.ComponentModel.DataAnnotations;
using MediatR;
using InnovateFuture.Application.DTOs;

namespace InnovateFuture.Application.Orders.Queries
{
    public class GetOrderQuery : IRequest<OrderDto>
    {
        [Required]
        public Guid OrderId { get; set; }
    }
}

