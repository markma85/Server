using FluentValidation;
using InnovateFuture.Application.DTOs;

namespace InnovateFuture.Application.Validators
{
    public class OrderDtoValidator : AbstractValidator<OrderDto>
    {
        public OrderDtoValidator()
        {
            //RuleFor(order => order.Id)
            //    .NotEqual(Guid.Empty).WithMessage("Order ID must not be an empty GUID.");

            //RuleFor(order => order.CustomerName)
            //    .NotEmpty().WithMessage("Customer name is requiredasdas.")
            //    .Length(5, 100).WithMessage("Customer name must be between 1 and 100 characters.");

            //RuleFor(order => order.TotalAmount)
            //    .GreaterThan(0).WithMessage("Total amount must be greater than zero.");

            //RuleFor(order => order.CreatedDate)
            //    .NotEmpty().WithMessage("Created date is required.")
            //    .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Created date cannot be in the future.");
        }
    }
}