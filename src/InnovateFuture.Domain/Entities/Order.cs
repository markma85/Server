using InnovateFuture.Domain.Exceptions;

namespace InnovateFuture.Domain.Entities;
    public class Order
    {
        public Guid Id { get; private set; }
        public string CustomerName { get; private set; }
        public DateTime CreatedDate { get; private set; }

        // Navigation property for EF Core
        public List<OrderItem> Items { get; private set; } = new();

        public decimal TotalAmount => Items.Sum(item => item.TotalPrice);

        public Order(string customerName)
        {
            Id = Guid.NewGuid();
            CustomerName = customerName ?? throw new IFArgumentException("Customer name cannot be null");
            CreatedDate = DateTime.UtcNow;
        }

        public void AddItem(string productName, int quantity, decimal unitPrice)
        {
            Items.Add(new OrderItem(productName, quantity, unitPrice));
        }
    }
