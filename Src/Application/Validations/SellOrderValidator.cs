using Domain.Entities;
using FluentValidation;

namespace Application.Validations;

public class SellOrderValidator : AbstractValidator<SellOrder>
{
    public SellOrderValidator()
    {
        RuleFor(s => s.StockName).NotEmpty();
        RuleFor(s => s.StockSymbol).NotEmpty();
        RuleFor(s => s.Price).InclusiveBetween(1, 1000);
        RuleFor(s => (int)s.Quantity).InclusiveBetween(1, 10000);
    }
}