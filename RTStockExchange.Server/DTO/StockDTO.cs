namespace RTStockExchange.Server.DTO
{
    public class StockDTO
    {
        public required string Name { get; set; }
        public required string Symbol { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
