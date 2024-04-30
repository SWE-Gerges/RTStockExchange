using RTStockExchange.Server.Core.Interfaces;
using RTStockExchange.Server.Core.Models;
using RTStockExchange.Server.Infrastructure.Data;

namespace RTStockExchange.Server.Infrastructure.Repositories
{
    public class StocksRepository : IRepository<Stock>
    {
        private readonly ApplicationDbContext _context;

        public StocksRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(Stock entity)
        {
            _context.Stocks.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Stock entity)
        {
            _context.Stocks.Remove(entity);
            _context.SaveChanges();
        }

        public Stock FindById(int id)
        {
            var stock = _context.Stocks.FirstOrDefault(s => s.Id == id);
            return stock;
        }

        public IEnumerable<Stock> GetAll()
        {
            var stocks = _context.Stocks.OrderBy(s => s.Name).ToList();
            return stocks;
        }

        public Stock Update(Stock entity)
        {
           _context.Stocks.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
