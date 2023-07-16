namespace Domain.Entities;

public class SellOrder
{
    public Guid SellOrderId { get; set; }
    public string StockSymbol { get; set; }
    public string StockName { get; set; }
    public DateTimeOffset DateAndTimeOfOffer { get; set; }
    public uint Quantity { get; set; }
    public double Price { get; set; }
}
