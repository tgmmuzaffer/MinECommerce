using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MinECommerce.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinECommerce.Service.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionStrings:MinECommerceUiContextConnection"];
            services.AddDbContext<MainDbContext>(options => options.UseSqlServer(connectionString));

        }
        public static void ConfigureServices(this IServiceCollection services)
        {

        }
    }
}
