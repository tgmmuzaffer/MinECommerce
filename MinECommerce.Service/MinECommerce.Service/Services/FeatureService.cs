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
    public class FeatureService : IFeatureService
    {
        private readonly MainDbContext _mainDbContext;

        public FeatureService(MainDbContext mainDbContext)
        {
            _mainDbContext = mainDbContext;
        }
        public async Task<bool> CreateFeature(Feature feature)
        {
            try
            {
                await _mainDbContext.AddAsync(feature);
                await _mainDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<bool> DeleteFeature(Feature feature)
        {
            try
            {
                var result = await _mainDbContext.Features.Include(a=>a.Discount).Include(b=>b.FeatureDescriptions).FirstOrDefaultAsync(x=>x.Id==feature.Id);
                if (result != null)
                {
                    _mainDbContext.Features.Remove(result);
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

        public async Task<Feature> GetFeature(int id)
        {
            try
            {
                var result = await _mainDbContext.Features.Include(a => a.Discount).Include(b => b.FeatureDescriptions).Include(p=>p.Products).FirstOrDefaultAsync(x => x.Id == id);
                if (result != null)
                {
                    return result;
                }
                return new Feature();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<List<Feature>> GetFeatures()
        {
            try
            {
                var result = await _mainDbContext.Features.Include(a => a.Discount).Include(b => b.FeatureDescriptions).Include(p => p.Products).ToListAsync();
                if (result != null)
                {
                    return result;
                }
                return new List<Feature>();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<bool> UpdateFeature(Feature feature)
        {
            try
            {
                _mainDbContext.Features.Update(feature);
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
