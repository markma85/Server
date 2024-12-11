using FluentValidation;

namespace InnovateFuture.Application.Orders.Commands
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            // Validate CustomerName
            RuleFor(order => order.CustomerName)
                .NotEmpty().WithMessage("Customer name is required.")
                .Length(5, 100).WithMessage("Customer name must be between 5 and 100 characters.");

            // Validate Items collection
            RuleFor(order => order.Items)
                .NotEmpty().WithMessage("Order must contain at least one item.");

            // Validate each item in the Items collection
            RuleForEach(order => order.Items).SetValidator(new CreateOrderItemValidator());
        }
    }

    public class CreateOrderItemValidator : AbstractValidator<CreateOrderCommand.CreateOrderItem>
    {
        public CreateOrderItemValidator()
        {
            RuleFor(item => item.ProductName)
                .NotEmpty().WithMessage("Product name is required.")
                .Length(3, 50).WithMessage("Product name must be between 3 and 50 characters.");

            RuleFor(item => item.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than 0.");

            RuleFor(item => item.UnitPrice)
                .GreaterThan(0).WithMessage("Unit price must be a positive value.");
        }
    }
}