namespace InnovateFuture.Application.DTOs;
public class OrderResponse
{
    public Guid Id { get; set; }
    public string CustomerName { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime CreatedDate { get; set; }
}
