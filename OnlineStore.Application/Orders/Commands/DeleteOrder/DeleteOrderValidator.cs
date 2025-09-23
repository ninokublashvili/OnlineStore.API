using FluentValidation;

namespace OnlineStore.Application.Orders.Commands.DeleteOrder
{
    public class DeleteOrderValidator : AbstractValidator<DeleteOrderCommand>
    {
        public DeleteOrderValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
