using Microsoft.EntityFrameworkCore;
namespace BinanceApi
{
    public class BinanceDbContext : DbContext
    {
        public DbSet<Crypto> Crypto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=.;Database=Binance;Trusted_Connection=True");
        }
    }
}
