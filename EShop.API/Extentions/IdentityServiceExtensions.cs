using EShop.Core.Entities.Identity;
using EShop.Infrastructure.Data.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EShop.API.Extentions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityService(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<AppIdentityDbContext>(opt =>
            {

                opt.UseSqlServer(configuration.GetConnectionString("IdentityConnection"));
            });
            return services;
        }
    }
}
