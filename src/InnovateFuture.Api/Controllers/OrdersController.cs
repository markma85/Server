using Microsoft.AspNetCore.Mvc;
using MediatR;
using InnovateFuture.Api.Models;
using InnovateFuture.Application.Orders.Commands.CreateOrder;
using InnovateFuture.Application.Orders.Query.GetOrder;


namespace InnovateFuture.Api.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new CreateOrderCommand
            {
                CustomerName = model.CustomerName,
                Items = model.Items.Select(item => new CreateOrderCommand.CreateOrderItem
                {
                    ProductName = item.ProductName,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice
                }).ToList()
            };

            var orderId = await _mediator.Send(command);
            return Ok(new { OrderId = orderId });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder([FromQuery]Guid id)
        {
            var query = new GetOrderQuery { OrderId = id };
            var order = await _mediator.Send(query);

            if (order == null)
                return NotFound();

            return Ok(order);
        }
    }
}