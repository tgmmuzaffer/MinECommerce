using Microsoft.EntityFrameworkCore;
using MinECommerce.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinECommerce.Context
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> opt) : base(opt)
        {

        }

        public DbSet<FeatureDescription> FeatureDescriptions { get; set; }
        public DbSet<Feature>  Features { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
