
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace InnovateFuture.Application.Orders.Commands
{
    public class CreateOrderCommand : IRequest<Guid>
    {
        [Required]//do simple model validation, can be caught in filter
        public string CustomerName { get; set; }
        [Required]
        public List<CreateOrderItem> Items { get; set; }

        public class CreateOrderItem
        {
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public decimal UnitPrice { get; set; }
        }
    }
}

