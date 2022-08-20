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
    public class DiscountService : IDiscountService
    {
        private readonly MainDbContext _mainDbContext;

        public DiscountService(MainDbContext mainDbContext)
        {
            _mainDbContext = mainDbContext;
        }
        public async Task<bool> CreateDiscount(Discount discount)
        {
            try
            {
                await _mainDbContext.AddAsync(discount);
                await _mainDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<bool> DeleteDiscount(Discount discount)
        {
            try
            {
                var result = await _mainDbContext.Discounts.FirstOrDefaultAsync(a => a.Id == discount.Id);
                if (result != null)
                {
                    _mainDbContext.Discounts.Remove(discount);
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

        public async Task<Discount> GetDiscount(int id)
        {
            try
            {
                var result = await _mainDbContext.Discounts.Include(a => a.Features).FirstOrDefaultAsync(x => x.Id == id);
                if (result != null)
                    return result;
                return new Discount();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<List<Discount>> GetDiscounts()
        {
            try
            {
                var result = await _mainDbContext.Discounts.Include(a => a.Features).ToListAsync();
                if (result != null)
                    return result;
                return new List<Discount>();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<bool> UpdateDiscount(Discount discount)
        {
            try
            {
                _mainDbContext.Discounts.Update(discount);
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
