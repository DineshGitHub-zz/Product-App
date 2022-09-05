using ProductWebApp.Models;
using System.Collections.Generic;

namespace ProductWebApp.Repository
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        IEnumerable<Product> GetAllProducts();
        Product GetProduct(int id);
        void DeleteProduct(int id);
        void UpdateProduct(Product product);
    }
}
