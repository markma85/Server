using FluentValidation;

namespace InnovateFuture.Application.Orders.Commands;

public class CreateOrderValidator: AbstractValidator<CreateOrderCommand>
{
    public CreateOrderValidator()
    {
        //todo: validation rule
    }
    private class CreateOrderItemValidator : AbstractValidator<CreateOrderCommand.CreateOrderItem>
    {
        public CreateOrderItemValidator()
        {
            //todo: validation rule
        }
    }
}