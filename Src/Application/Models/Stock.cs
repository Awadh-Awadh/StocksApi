namespace Application.Models;

public class Stock
{
    public string? StockSymbol { get; set; }
    public string? StockName { get; set; }

    public override bool Equals(object obj) => obj is Stock stock && StockSymbol == stock.StockSymbol && StockName == stock.StockName;
}