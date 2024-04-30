using Microsoft.EntityFrameworkCore;
using RTStockExchange.Server.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTStockExchange.Server.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) 
            : base(options)
        {
            
        }

        public DbSet<Stock> Stocks { get; set; }
    }
}
