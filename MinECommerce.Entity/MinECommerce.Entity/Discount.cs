using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinECommerce.Entity
{
    public class Discount
    {
        public int Id { get; set; }
        public int Rate { get; set; }
        public List<Feature>? Features
        {
            get; set;
        }
    }
}
