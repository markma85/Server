namespace MyProject.Api.Models
{
    public class CreateOrderModel
    {
        [Required]
        public string CustomerName { get; set; }

        [Required]
        public List<OrderItemModel> Items { get; set; }

        public class OrderItemModel
        {
            [Required]
            public string ProductName { get; set; }

            [Range(1, int.MaxValue)]
            public int Quantity { get; set; }

            [Range(0.01, double.MaxValue)]
            public decimal UnitPrice { get; set; }
        }
    }
}