using Microsoft.AspNetCore.Http;
using MinECommerce.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinECommerce.Service.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public IFormFile? Image { get; set; }
        public List<int> FeaturIds { get; set; } = new List<int>();
    }
}
