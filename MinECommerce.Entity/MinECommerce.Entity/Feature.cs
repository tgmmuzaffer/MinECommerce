using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinECommerce.Entity
{
    public class Feature
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int DiscountId { get; set; }
        public Discount? Discount { get; set; }
        public List<FeatureDescription> FeatureDescriptions { get; set; } = new List<FeatureDescription>();
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
