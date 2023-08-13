using EShop.Core.Entities.Identity;
using EShop.Infrastructure.Data.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

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

            services.AddIdentityCore<AppUser>(c =>
            {

                c.SignIn.RequireConfirmedEmail = false;
                c.SignIn.RequireConfirmedAccount = false;
                c.SignIn.RequireConfirmedPhoneNumber = false;
                c.Lockout.AllowedForNewUsers = true;
                c.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
                c.Lockout.MaxFailedAccessAttempts = 3;
            })
            .AddEntityFrameworkStores<AppIdentityDbContext>()
            .AddSignInManager<SignInManager<AppUser>>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, option =>
             {
                 option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                 {
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:Key"])),
                     ValidIssuer = configuration["Token:Issuer"],
                     ValidateAudience = false,
                     ValidateIssuer = true

                 };
             });
            services.AddAuthorization();
         

            return services;
        }
    }
}
