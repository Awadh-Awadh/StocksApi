using System.ComponentModel.DataAnnotations;

namespace Application.Dtos;

public abstract record RequestDto
{
    public string StockSymbol { get; init; }
    public string StockName { get; init; }
    public DateTimeOffset DateAndTimeOfOffer { get; init; }
    [Range(1, 100000)]
    public uint Quantity { get; init; }
    [Range(1, 100000)]
    public double DoublePrice { get; init; }
}