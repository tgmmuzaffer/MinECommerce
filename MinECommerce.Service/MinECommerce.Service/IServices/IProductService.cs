using MinECommerce.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinECommerce.Service.IServices
{
    public interface IProductService
    {
        Task<Product> GetProduct(int id);
        Task<List<Product>> GetProducts();
        Task<bool> CreateProduct(Product product);
        Task<bool> DeleteProduct(Product product);
        Task<bool> UpdateProducte(Product product);
    }
}
