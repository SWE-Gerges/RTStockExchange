using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RTStockExchange.Server.Core.Interfaces;
using RTStockExchange.Server.Core.Models;
using RTStockExchange.Server.DTO;
using RTStockExchange.Server.Infrastructure.Repositories;

namespace RTStockExchange.Server.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly IRepository<Stock> _stocksRepository;

        public StocksController(IRepository<Stock> stocksRepository)
        {
            _stocksRepository = stocksRepository;
        }


        [HttpGet(Name = "Stocks")]
        public IActionResult Index()
        {
            var stocks = _stocksRepository.GetAll();
            return Ok(stocks);
        }

        [HttpPost]
        public IActionResult Create([FromForm] StockDTO stockDTO)
        {
            var stock = new Stock
            { 
              Name = stockDTO.Name,
              Symbol = stockDTO.Symbol,
              Price = stockDTO.Price,
              Quantity = stockDTO.Quantity
            
            };

            _stocksRepository.Create(stock);
            return Created();
        }

        [HttpPut("id")]
        public IActionResult Update(int id, [FromForm] StockDTO stockDTO)
        {
            var stock = _stocksRepository.FindById(id);
            stock.Name = stockDTO.Name;
            stock.Symbol = stockDTO.Symbol;
            stock.Price = stockDTO.Price;
            stock.Quantity = stockDTO.Quantity;
            _stocksRepository.Update(stock);
            return Ok();
        }

        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            var stock = _stocksRepository.FindById(id);
            _stocksRepository.Delete(stock);
            return Ok();
        }
    }
}
