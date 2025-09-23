using FluentValidation;

namespace OnlineStore.Application.ProductCatalog.Commands.DecreaseStock
{
    public class DecreaseStockValidator : AbstractValidator<DecreaseStockCommand>
    {
        public DecreaseStockValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).NotEmpty();
            RuleFor(x => x.Quantity).GreaterThan(0);
        }
    }
}
