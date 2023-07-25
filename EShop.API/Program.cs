using EShop.API.Errors;
using EShop.API.Extentions;
using EShop.API.Middleware;
using EShop.Core.Interfaces;
using EShop.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EShop.API
{
    public class Program
    {
        public static async Task  Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddApplicationServices(builder.Configuration);

            var app = builder.Build();
            app.UseStatusCodePagesWithReExecute("/errors/{0}");
            app.UseMiddleware<ExceptionMiddleware>();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthorization();


            app.MapControllers();
            using(var scopped = app.Services.CreateScope())
            {
                var context = scopped.ServiceProvider.GetRequiredService<StoreDbContext>();
                var logger = scopped.ServiceProvider.GetRequiredService<ILogger<Program>>();
                try
                {
                    await context.Database.MigrateAsync();
                    await StoreContextSeedData.SeedAsync(context);
                }
                catch (Exception ex)
                {

                    logger.LogError(ex, "an Error occurred during migration");
                }
            }

            app.Run();
        }
    }
}