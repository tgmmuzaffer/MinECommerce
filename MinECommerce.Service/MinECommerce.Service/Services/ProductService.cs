using Microsoft.EntityFrameworkCore;
using MinECommerce.Context;
using MinECommerce.Entity;
using MinECommerce.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinECommerce.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly MainDbContext _mainDbContext;

        public ProductService(MainDbContext mainDbContext)
        {
            _mainDbContext = mainDbContext;
        }
        public async Task<bool> CreateProduct(Product product)
        {
            try
            {
                await _mainDbContext.Products.AddAsync(product);
                await _mainDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<bool> DeleteProduct(Product product)
        {
            try
            {
                var result = await _mainDbContext.Products.FirstOrDefaultAsync(a => a.Id == product.Id);

                if (result != null)
                {
                    _mainDbContext.Products.Remove(result);
                    await _mainDbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<Product> GetProduct(int id)
        {
            try
            {
                var result = await _mainDbContext.Products.Include(a=>a.Features).FirstOrDefaultAsync(a => a.Id == id);
                if (result != null)
                {
                    return result;
                }
                return new Product();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<List<Product>> GetProducts()
        {
            try
            {
                var result = await _mainDbContext.Products.Include(a => a.Features).ToListAsync();
                if (result != null)
                {
                    return result;
                }
                return new List<Product>();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<bool> UpdateProducte(Product product)
        {
            try
            {
                _mainDbContext.Products.Update(product);
                await _mainDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
