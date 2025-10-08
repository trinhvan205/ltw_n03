using Microsoft.EntityFrameworkCore;

namespace TvTDay08EFCF.Models
{
    public class K64CNT1DbContext:DbContext
    {
        public K64CNT1DbContext(DbContextOptions<K64CNT1DbContext> options):
            base(options)
        { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
