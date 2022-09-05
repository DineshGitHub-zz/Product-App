using Microsoft.EntityFrameworkCore;
using ProductWebApp.Models;

namespace ProductWebApp.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
    }
}
