using Microsoft.AspNetCore.Mvc;
using MediatR;
using InnovateFuture.Application.Orders.Commands;
using InnovateFuture.Application.Orders.Queries;

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
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

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