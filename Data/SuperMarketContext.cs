using Microsoft.EntityFrameworkCore;
using SuperMarketApp.Models;

namespace SuperMarketApp.Data
{
    public class SuperMarketContext : DbContext
    {
        public SuperMarketContext(DbContextOptions<SuperMarketContext> options)
            : base(options)
        {
        }

        public DbSet<Gudang> Gudangs { get; set; }
        public DbSet<Barang> Barangs { get; set; }
    }
}
