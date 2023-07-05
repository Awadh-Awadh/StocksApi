using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace Application.Dtos;

public abstract record OrderResponseDto
{
    public Guid OrderId { get; init; }
    [Required]
    public string StockSymbol { get; init; }
    [Required]
    public string StockName { get; init; }
    public DateTimeOffset DateAndTimeOfOrder { get; init; }
    [Range(1, 10000)]
    public uint Quantity { get; init; }
    [Range(1, 10000)]
    public double Price { get; init; }
    public double TradeAmount { get; init; }
}