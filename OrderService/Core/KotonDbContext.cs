using Microsoft.EntityFrameworkCore;
using OrderService.Models;

namespace OrderService.Core
{
    public class KotonDbContext : DbContext
    {
        public KotonDbContext()
        {

        }
        public KotonDbContext(DbContextOptions<KotonDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Data Source = 192.168.1.109; Initial Catalog = KotonOrderDb; User = sa; Password = 23032021Sahin");
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
