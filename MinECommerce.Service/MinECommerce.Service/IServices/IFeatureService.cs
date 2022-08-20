using MinECommerce.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinECommerce.Service.IServices
{
    public interface IFeatureService
    {
        Task<Feature> GetFeature(int id);
        Task<List<Feature>> GetFeatures();
        Task<bool> CreateFeature(Feature feature);
        Task<bool> DeleteFeature(Feature feature);
        Task<bool> UpdateFeature(Feature feature);
    }
}
