using System.ComponentModel.DataAnnotations;

namespace InnovateFuture.Api.Models.Requests;

public class CreateOrderRequest
{
    [Required(ErrorMessage = "Customer name is required.")]
    [MaxLength(100, ErrorMessage = "Customer name cannot exceed 100 characters.")]
    public string CustomerName { get; set; }
    
    [Required(ErrorMessage = "At least one order item is required.")]
    [MinLength(1, ErrorMessage = "At least one order item is required.")]
    public List<CreateOrderItem> Items { get; set; }

    public class CreateOrderItem
    {
        [Required(ErrorMessage = "Product name is required.")]
        public string ProductName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than zero.")]
        public int Quantity { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Unit price must be greater than zero.")]
        public decimal UnitPrice { get; set; }
    }
}