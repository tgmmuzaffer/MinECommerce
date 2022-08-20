using MinECommerce.Core.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinECommerce.Entity
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public string? Image { get; set; }
        public List<Feature> Features { get; set; } = new List<Feature>();

    }
}
