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
    public class FeatureDescriptionService : IFeatureDescriptionService
    {
        private readonly MainDbContext _mainDbContext;

        public FeatureDescriptionService(MainDbContext mainDbContext)
        {
            _mainDbContext = mainDbContext;
        }

        public async Task<bool> CreateFeatureDescription(FeatureDescription featureDescription)
        {
            try
            {
                await _mainDbContext.FeatureDescriptions.AddAsync(featureDescription);
                await _mainDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<bool> DeleteFeatureDescription(FeatureDescription featureDescription)
        {
            try
            {
                var featureDescr = await GetFeatureDescriptionWithTracking(featureDescription.Id);
                if (featureDescr != null)
                {
                   _mainDbContext.FeatureDescriptions.Remove(featureDescription);
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

        public async Task<FeatureDescription> GetFeatureDescription(int id)
        {
            try
            {
                var result= await  _mainDbContext.FeatureDescriptions.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
                if (result != null)
                {
                    return result;
                }
                return new FeatureDescription();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<List<FeatureDescription>> GetFeaturesDescription()
        {
            try
            {
                var result = await _mainDbContext.FeatureDescriptions.AsNoTracking().ToListAsync();
                if (result != null)
                {
                    return result;
                }
                return new List<FeatureDescription> { new FeatureDescription() };
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<bool> UpdateFeatureDescription(FeatureDescription featureDescription)
        {
            try
            {
                    _mainDbContext.FeatureDescriptions.Update(featureDescription);
                    await _mainDbContext.SaveChangesAsync();
                    return true;;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        private async Task<FeatureDescription> GetFeatureDescriptionWithTracking(int id)
        {
            try
            {
                return await _mainDbContext.FeatureDescriptions.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
