using FluentValidation;

namespace InnovateFuture.Application.Orders.Commands;

public class CreateOrderValidator: AbstractValidator<CreateOrderCommand>
{
    public CreateOrderValidator()
    {
        RuleFor(order => order.CustomerName)
            .NotEmpty().WithMessage("Customer name is requiredasdas.")
            .Length(5, 100).WithMessage("Customer name must be between 5 and 100 characters.");
    }
    private class CreateOrderItemValidator : AbstractValidator<CreateOrderCommand.CreateOrderItem>
    {
        public CreateOrderItemValidator()
        {
            //todo: validation rule
        }
    }
}