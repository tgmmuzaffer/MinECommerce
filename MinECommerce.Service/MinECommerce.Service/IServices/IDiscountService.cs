using MinECommerce.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinECommerce.Service.IServices
{
    public interface IDiscountService
    {
        Task<Discount> GetDiscount(int id);
        Task<List<Discount>> GetDiscounts();
        Task<bool> CreateDiscount(Discount discount);
        Task<bool> DeleteDiscount(Discount discount);
        Task<bool> UpdateDiscount(Discount discount);
    }
}
