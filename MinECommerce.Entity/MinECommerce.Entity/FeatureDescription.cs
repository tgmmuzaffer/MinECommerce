using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinECommerce.Entity
{
    public class FeatureDescription
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public int? FeatureId { get; set; }
        public Feature? Feature{ get; set; }
    }
}
