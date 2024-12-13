using FluentValidation;

namespace InnovateFuture.Application.Commands.Orders;
public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        // Business rule: Ensure customer name starts with "VIP" for priority orders
        RuleFor(order => order.CustomerName)
            .Must(name => name.StartsWith("VIP", StringComparison.OrdinalIgnoreCase))
            .WithMessage("Customer name must start with 'VIP' for priority orders.");

        // Business rule: Ensure total number of items does not exceed a maximum limit
        RuleFor(order => order.Items)
            .Must(items => items.Count <= 10)
            .WithMessage("An order cannot contain more than 10 items.");

        // Validate each item in the Items collection
        RuleForEach(order => order.Items).SetValidator(new CreateOrderItemValidator());
    }
}

public class CreateOrderItemValidator : AbstractValidator<CreateOrderCommand.CreateOrderItem>
{
    public CreateOrderItemValidator()
    {
        RuleFor(item => item)
            .Must(item => item.Quantity * item.UnitPrice <= 1000)
            .WithMessage("Total price for a single item cannot exceed $1000.");

        // Business rule: Check for product-specific logic, e.g., restricted products
        RuleFor(item => item.ProductName)
            .Must(product => !RestrictedProducts.Contains(product))
            .WithMessage("This product is restricted and cannot be ordered.");

    }
    private static readonly HashSet<string> RestrictedProducts = new HashSet<string>
    {
        "RestrictedItem1",
        "RestrictedItem2"
    };
}