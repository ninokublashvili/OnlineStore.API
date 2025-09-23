using FluentValidation;

namespace OnlineStore.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderRequestValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderRequestValidator()
        {
            RuleFor(x => x.Items).NotEmpty();
            RuleForEach(x => x.Items).ChildRules(i =>
            {
                i.RuleFor(y => y.ProductId).GreaterThan(0);
                i.RuleFor(y => y.Quantity).GreaterThan(0);
            });
        }
    }
}
