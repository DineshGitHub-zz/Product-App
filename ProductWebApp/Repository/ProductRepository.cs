using Microsoft.EntityFrameworkCore;
using ProductWebApp.Data;
using ProductWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProductWebApp.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _context;
        public ProductRepository(ProductContext context)
        {
            _context = context;
        }

        public void DeleteProduct(int id)
        {
            _context.Database.ExecuteSqlRaw("EXECUTE dbo.DeleteProduct {0}", id);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.FromSqlRaw("EXECUTE dbo.GetProducts").ToList();
        }

        public Product GetProduct(int id)
        {
            return _context.Products.FromSqlRaw<Product>("EXECUTE dbo.GetProductById {0}", id).ToList().FirstOrDefault();
        }

        public void AddProduct(Product product)
        {
            _context.Database.ExecuteSqlRaw("EXECUTE dbo.AddProduct {0}, {1}", product.ProductName, product.Qty );
        }

        public void UpdateProduct(Product product)
        {
            _context.Database.ExecuteSqlRaw("EXECUTE dbo.UpdateProduct {0}, {1}, {2}", product.Id, product.ProductName, product.Qty);
        }
    }
}
