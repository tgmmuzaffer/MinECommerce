using MinECommerce.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinECommerce.Service.IServices
{
    public interface IFeatureDescriptionService
    {
        Task<FeatureDescription> GetFeatureDescription(int id);
        Task<List<FeatureDescription>> GetFeaturesDescription();
        Task<bool> CreateFeatureDescription(FeatureDescription featureDescription);
        Task<bool> DeleteFeatureDescription(FeatureDescription featureDescription);
        Task<bool> UpdateFeatureDescription(FeatureDescription featureDescription);

    }
}
