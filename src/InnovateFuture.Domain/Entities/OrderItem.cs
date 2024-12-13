using InnovateFuture.Domain.Exceptions;

namespace InnovateFuture.Domain.Entities
{
    public class OrderItem
    {
        public Guid Id { get; private set; } // Primary key for OrderItem
        public Guid OrderId { get; private set; } // Foreign key to Order

        public string ProductName { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal TotalPrice => Quantity * UnitPrice;

        public OrderItem(string productName, int quantity, decimal unitPrice)
        {
            Id = Guid.NewGuid();

            if (string.IsNullOrWhiteSpace(productName))
                throw new IFArgumentException("Product name is required.");

            if (quantity <= 0)
                throw new IFArgumentException("Quantity must be greater than zero.");

            if (unitPrice <= 0)
                throw new IFArgumentException("Unit price must be greater than zero.");

            ProductName = productName;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }
    }
}