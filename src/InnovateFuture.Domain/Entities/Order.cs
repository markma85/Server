public class Order
{
    public Guid Id { get; private set; }
    public string CustomerName { get; private set; }
    public DateTime CreatedDate { get; private set; }
    private readonly List<OrderItem> _items = new();

    public decimal TotalAmount => _items.Sum(item => item.TotalPrice);

    public Order(string customerName)
    {
        Id = Guid.NewGuid();
        CustomerName = customerName ?? throw new ArgumentNullException(nameof(customerName));
        CreatedDate = DateTime.UtcNow;
    }

    public void AddItem(string productName, int quantity, decimal unitPrice)
    {
        _items.Add(new OrderItem(productName, quantity, unitPrice));
    }
}