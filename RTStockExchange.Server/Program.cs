

using Microsoft.EntityFrameworkCore;
using RTStockExchange.Server.Core.Interfaces;
using RTStockExchange.Server.Core.Models;
using RTStockExchange.Server.Infrastructure.Data;
using RTStockExchange.Server.Infrastructure.Repositories;

namespace RTStockExchange.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            //Getting ConnectionString
            var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<ApplicationDbContext>(options =>options.UseSqlServer(ConnectionString));
            // Add services to the container.

            builder.Services.AddTransient<IRepository<Stock>, StocksRepository>();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
