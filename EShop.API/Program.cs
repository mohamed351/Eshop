using EShop.Core.Interfaces;
using EShop.Infrastructure.Data;
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
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<StoreDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            var app = builder.Build();

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