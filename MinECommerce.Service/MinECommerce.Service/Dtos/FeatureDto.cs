using MinECommerce.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinECommerce.Service.Dtos
{
    public class FeatureDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int DiscountId { get; set; }
        public List<int> FeatureDescriptionIds { get; set; } = new List<int>();
    }
}
