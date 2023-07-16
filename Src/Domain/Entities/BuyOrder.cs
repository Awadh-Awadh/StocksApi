
namespace Domain.Entities;

public class BuyOrder
{
    public Guid BuyOrderId { get; set; }
    public string StockSymbol { get; set; }
    public string StockName { get; set; }
    public DateTimeOffset DateAndTimeOfOrder { get; set; }
    public uint Quantity { get; set; }
    public double Price { get; set; }
}
