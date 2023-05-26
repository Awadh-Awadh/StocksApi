using System.Reflection.Metadata.Ecma335;

namespace Application.Dtos;

public abstract record OrderResponseDto
{
    public Guid OrderId { get; init; }
    public string StockSymbol { get; init; }
    public string StockName { get; init; }
    public DateTimeOffset DateAndTimeOfOrder { get; init; }
    public uint Quantity { get; init; }
    public double Price { get; init; }
    public double TradeAmount { get; init; }
}