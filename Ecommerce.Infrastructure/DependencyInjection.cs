using Ecommerce.Domain.Interfaces.Repository;
using Ecommerce.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            
            var cs = configuration.GetConnectionString("Default");
            //services.AddDbContext<EcommerceDbContext>(opt => opt.UseSqlServer(cs));

            services.AddDbContext<EcommerceDbContext>(options =>
                    options.UseSqlite(cs));
            return services;
        }
    }
}
