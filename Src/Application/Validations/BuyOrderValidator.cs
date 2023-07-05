using Domain.Entities;
using FluentValidation;

namespace Application.Validations;

public class BuyOrderValidator : AbstractValidator<BuyOrder>
{
    public BuyOrderValidator()
    {
        RuleFor(c => c.StockSymbol).NotEmpty().NotNull();
        RuleFor(c => c.StockName).NotNull();
        RuleFor(c => (int)c.Quantity).InclusiveBetween(1, 10000);
        RuleFor(c => c.Price).InclusiveBetween(1, 1000);
    }
}
