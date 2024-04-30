

using System.ComponentModel.DataAnnotations.Schema;

namespace RTStockExchange.Server.Core.Models;

public class Stock
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Symbol { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
}
