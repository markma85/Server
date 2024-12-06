public class GetOrderQuery : IRequest<OrderDto>
{
    public Guid OrderId { get; set; }
}